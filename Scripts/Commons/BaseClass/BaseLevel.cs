using Godot;
using MartianMike.Scripts.Commons.Controls;
using MartianMike.Scripts.Commons.LevelClock;

namespace MartianMike.Scripts.Commons.Baseclass
;

public partial class BaseLevel: Node2D
{
    private Marker2D _startMarker;
    private Marker2D _endMarker;
    private ExitArea _exitArea;
    private Player _player;
    private LevelTimer _levelTimer;
    private BaseUi _ui;
    protected bool IsFinalLevel = false;
    [Export] private PackedScene _nextLevel;
    [Export] private int _levelTime = 5;


    public override void _Ready()
    {
        this._loadDependencies();
        this._player = BasePlayer.LoadBasePlayer(this._startMarker, this);
        this._ui = new BaseUi(this, this._levelTime);
        BaseDeadZone.BuildDeadZone(this._endMarker,this);
        this._levelTimer = new LevelTimer(this, this._player, this._levelTime);
        this._connectSignal();
    }
    
    public override void _Process(double delta)
    {
        this._checkInput();
    }
    
    private void _checkInput()
    {
        if (Input.IsActionJustPressed(GameControls.Quit)) this.GetTree().Quit();
        if (Input.IsActionJustPressed(GameControls.Reset)) this.GetTree().ReloadCurrentScene();
    }
    
    private void _loadDependencies()
    {
        this._startMarker = this.GetNode<Start>("Start").GetSpawnPosition();
        this._endMarker = this.GetNode<Marker2D>("EndMarker");
        this._exitArea = this.GetNode<ExitArea>("ExitArea");
    }

    private void _connectSignal()
    {
        this._exitArea.Connect("body_entered", Callable.From((Player p) => this._onExitBodyEntered(p)));
        this._levelTimer.Timer.Connect("timePass", Callable.From((int time) => this._ui.Ui.UpdateTimerHud(time)));
    }

    private void _onExitBodyEntered(Player p)
    {
        this._levelTimer.StopTimer();
        p.TogglePlayer();
        this._exitArea.Animate();
        this._changeLevel();
    }

    private async void _changeLevel()
    {
        await this.ToSignal(this.GetTree().CreateTimer(1.5f), "timeout");
        if (this._nextLevel != null)
        {
            this.QueueFree();
            this.GetTree().ChangeSceneToPacked(this._nextLevel);
        }

        if (this.IsFinalLevel)
        {
            this._ui.Ui.ShowWinScreen();
        }
    }
}