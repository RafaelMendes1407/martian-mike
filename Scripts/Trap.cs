using Godot;

namespace MartianMike.Scripts;

public partial class Trap : Node2D
{

	private Area2D _trap;
	private AudioStream _audioStream;
	public override void _Ready()
	{
		this._trap = this.GetNode<Area2D>("Area2D");
		this._trap.Connect("body_entered", Callable.From((Player p) => this._onBodyEnteredEventHandler(p)));
		this._audioStream = this.GetNode<AudioStream>("/root/AudioPlayer");
	}
	
	public override void _Process(double delta)
	{
	}

	private async void _onBodyEnteredEventHandler(Player p)
	{
		this._audioStream.PlaySFX("hurt");
		p.DefinePlayerPosition();
	}
}