
using Godot;
using Godot.Collections;
using MartianMike.Scripts.Commons.Baseclass;

namespace MartianMike.Scripts.Commons.LevelClock;

public class LevelTimer
{

    public Timer Timer { get; private set; }
    private int _timeLeft = 5;
    private int _levelTime = 5;
    private Player _player;
    [Signal]
    public delegate void TimePassEventHandler(string ev);
    
    public LevelTimer(BaseLevel baseLevel, Player player, int timeout)
    {
        this._timeLeft = timeout;
        this._levelTime = timeout;
        this._player = player;
        this._createTimer(baseLevel);
    }
    
    private void _createTimer(BaseLevel baseLevel)
    {
        this.Timer = new Timer();
        this.Timer.Name = "LevelTimer";
        this.Timer.WaitTime = 1;
        this.Timer.Connect("timeout", Callable.From(this._onLevelTimeout));
        baseLevel.AddChild(this.Timer);
        this.Timer.AddUserSignal("timePass", new Array(){"time"});
        this.Timer.Start();
    }

    private void _onLevelTimeout()
    {
        this._timeLeft -= 1;
        if (this._timeLeft < 0)
        {
            this._timeLeft = this._levelTime;
            this._player.DefinePlayerPosition();
        }
        
        this.Timer.EmitSignal("timePass", this._timeLeft);
    }

    public void StopTimer()
    {
        this.Timer.Stop();
    }
}