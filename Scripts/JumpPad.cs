using Godot;
using MartianMike.Scripts.Commons.Constants;

namespace MartianMike.Scripts;

public partial class JumpPad : Area2D
{
	[Export] public int JumpForce = 300;
	private AnimatedSprite2D _animatedSprite2D;
	public override void _Ready()
	{
		this._animatedSprite2D = this.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		this.Connect("body_entered", Callable.From((Player p) => this._onBodyEnteredEventHandler(p)));
	}

	public override void _Process(double delta)
	{
	}

	public void _onBodyEnteredEventHandler(Player p)
	{
		this._animatedSprite2D.Play(PlayersMove.Jump);
		p.Jump(this.JumpForce);
	}
}