using Godot;

namespace MartianMike.Scripts;

public partial class StartScreen : Control
{
	private Button _startButton;
	private Button _quitButton;

	public override void _Ready()
	{
		this._startButton = this.GetNode<Button>("Container/StartButton");
		this._quitButton = this.GetNode<Button>("Container/QuitButton");
		this._startButton.Connect("pressed", Callable.From(this._onStart));
		this._quitButton.Connect("pressed", Callable.From(this._onQuit));
	}
	
	public override void _Process(double delta)
	{
	}

	private void _onStart()
	{
		this.GetTree().ChangeSceneToFile("res://scenes/level.tscn");
	}

	private void _onQuit()
	{
		this.GetTree().Quit();
	}
}