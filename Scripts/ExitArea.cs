using Godot;

namespace MartianMike.Scripts;

public partial class ExitArea : Area2D
{
	private AnimatedSprite2D _animatedSprite2D;
	public override void _Ready()
	{
		this._animatedSprite2D = this.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public void Animate()
	{
		this._animatedSprite2D.Play("default");
	}
}