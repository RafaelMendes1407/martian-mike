using Godot;
using MartianMike.Scripts.Commons.Controls;
using MartianMike.Scripts.Commons.Constants;

namespace MartianMike.Scripts;

public partial class Player : CharacterBody2D
{
	[Export] public int Gravity = 400;
	[Export] public int Speed = 125;
	[Export] public int JumpForce = 200;
	public Marker2D StartMarker { get; set; }
	private AnimatedSprite2D _animatedSprite2D;
	private bool _isActive = true;
	private AudioStream AudioPlayer;

	public override void _Ready()
	{
		this._animatedSprite2D = this.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		this.AudioPlayer = this.GetNode<AudioStream>("/root/AudioPlayer");
	}
	
	public override void _PhysicsProcess(double delta)
	{ 
		this._movement(delta);
		this.MoveAndSlide();
	}

	public void Jump(int jumpForce)
	{
		AudioPlayer.PlaySFX("jump");
		jumpForce *= -1;
		this._updateVelocity(this.Velocity.X, jumpForce);
	}

	public void DefinePlayerPosition(Marker2D initialPosition)
	{
		this._updateVelocity(0,0);
		this.StartMarker = initialPosition;
		this.Position = this.StartMarker.GlobalPosition;
		this._isActive = true;
	}
	
	public void DefinePlayerPosition()
	{
		this.DefinePlayerPosition(this.StartMarker);
	}

	public void TogglePlayer()
	{
		this._isActive = !this._isActive;
		this._updateVelocity(0,this.Velocity.Y);
	}

	private void _movement(double delta)
	{
		var isOnFloor = this.IsOnFloor();
		if (!isOnFloor)
		{
			this._updateVelocity(this.Velocity.X, this.Velocity.Y + (float)(this.Gravity * delta));
			if (this.Velocity.Y > 500)
			{
				this._updateVelocity(this.Velocity.X, 500);
			}
		}

		var direction = _getDirection();
		if (this._isActive)
		{
			this._updateVelocity(direction * this.Speed, this.Velocity.Y);

			if (Input.IsActionJustPressed(GameControls.Jump) && isOnFloor)
			{
				this.Jump(this.JumpForce);
			}
		}
		this._updateAnimation(direction, isOnFloor);
	}

	private void _updateAnimation(float direction, bool isOnFloor)
	{
		if (!this._isActive) direction = 0;
		if (direction != 0) this._animatedSprite2D.FlipH = ((int) direction == -1);
		if (isOnFloor)
		{
			this._animatedSprite2D.Play(direction == 0 ? PlayersMove.Idle : PlayersMove.Run);
		}
		else
		{
			this._animatedSprite2D.Play(this.Velocity.Y > 0 ? PlayersMove.Fall : PlayersMove.Jump);
		}
	}

	private void _updateVelocity(float x, float y)
	{
		this.Velocity = new Vector2(x, y);
	}
	
	private float _getDirection()
	{
		return Input.GetAxis(GameControls.MoveLeft, GameControls.MoveRight);
	}
}