using Godot;

namespace MartianMike.Scripts;

public partial class Background : ParallaxBackground
{
	[Export] public int ScrollSpeed = 15;
	[Export] public CompressedTexture2D GbTexture;
	private Sprite2D _sprite2D;
	public override void _Ready()
	{
		this._sprite2D = this.GetNode<Sprite2D>("ParallaxLayer/Sprite2D");
		this.GbTexture ??= ResourceLoader.Load<CompressedTexture2D>("res://assets/textures/bg/Blue.png");
		this._sprite2D.Texture = this.GbTexture;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Rect2 rect = this._sprite2D.RegionRect;
		rect.Position = new Vector2(rect.Position.X + (float) delta * this.ScrollSpeed,rect.Position.Y + (float) delta * ScrollSpeed);
		if(this._sprite2D.RegionRect.Position >= new Vector2(64,64)) rect.Position = Vector2.Zero;
		this._sprite2D.RegionRect = rect;
	}
}