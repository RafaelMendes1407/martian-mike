using Godot;

namespace MartianMike.Scripts;

public partial class WinScreen : Control
{
	private Button _button;
	public override void _Ready()
	{
		this._button = this.GetNode<Button>("Button");
		this._button.Connect("pressed", Callable.From(this._buttonPressed));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _buttonPressed()
	{
		this.GetTree().ChangeSceneToFile("res://scenes/start_screen.tscn");
	}
}