using Godot;

namespace MartianMike.Scripts;

public partial class AudioStream : Node2D
{
	private AudioStreamWav _hurt;
	private AudioStreamWav _jump;
	public override void _Ready()
	{
		this._hurt = GD.Load<AudioStreamWav>("res://assets/audio/hurt.wav");
		this._jump = GD.Load<AudioStreamWav>("res://assets/audio/jump.wav");
	}

	public async void PlaySFX(string sfx)
	{
		AudioStreamWav stream = null;
		switch (sfx)
		{
			case "hurt":
				stream = this._hurt;
				break;
			case "jump":
				stream = this._jump;
				break;
			default:
				return;
		}

		var asp = new AudioStreamPlayer();
		asp.Stream = stream;
		asp.Name = "SFX";
		this.AddChild(asp);
		asp.Play();
		await asp.ToSignal(asp, "finished");
		asp.QueueFree();
	}
}