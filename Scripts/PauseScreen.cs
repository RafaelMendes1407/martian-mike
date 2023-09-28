using Godot;
using MartianMike.Scripts.Commons.Controls;

namespace MartianMike.scripts;

public partial class PauseScreen : Control
{

	private bool _isPaused = false;
	public override void _Ready()
	{
		this.ProcessMode = ProcessModeEnum.Always;
	}
	
	public override void _Process(double delta)
	{
		this._unhandledInput();
	}
	
	private void _unhandledInput()
	{
		if(Input.IsActionJustPressed(GameControls.Pause))
		{
			this._setPaused(!this._isPaused);
		}
	}

	private void _setPaused(bool paused)
	{
		this._isPaused = paused;
		this.Visible = this._isPaused;
		this.GetTree().Paused = this._isPaused;
	}
}