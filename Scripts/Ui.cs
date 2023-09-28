using Godot;

namespace MartianMike.Scripts;

public partial class Ui : CanvasLayer
{
	private TimerHud _timerHud;
	private WinScreen _winScreen;
	public override void _Ready()
	{
		this._timerHud = this.GetNode<TimerHud>("TimerHud");
		this._winScreen = this.GetNode<WinScreen>("WinScreen");
		this._winScreen.Visible = false;
	}
	
	public void UpdateTimerHud(int value)
	{
		this._timerHud.UpdateTimerHud(value);
	}

	public void ShowWinScreen()
	{
		this._winScreen.Visible = true;
		this._timerHud.Visible = false;
	}
}