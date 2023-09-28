using Godot;

namespace MartianMike.Scripts;

public sealed partial class TimerHud : Control
{

	private Label _timerLabel;
	private AnimationPlayer _animationPlayer;
	public override void _Ready()
	{
		this._timerLabel = this.GetNode<Label>("TimerLabel");
		this._animationPlayer = this.GetNode<AnimationPlayer>("AnimationPlayer");
	}
	

	public void UpdateTimerHud(int timer)
	{
		this._playAnimation(timer);
		this._timerLabel.Text = "TIME: " + timer;
	}

	private void _playAnimation(int timer)
	{
		if (timer <= 10)
		{
			this._animationPlayer.Play("time_over");
			return;
		}
		this._animationPlayer.Stop();
	}
}