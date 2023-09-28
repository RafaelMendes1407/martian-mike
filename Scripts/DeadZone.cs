using Godot;

namespace MartianMike.Scripts;

public partial class DeadZone: Area2D
{
    private CollisionPolygon2D _collisionPolygon2D;
    public override void _Ready()
    {
        this.Connect("body_entered", Callable.From((Player p) => this._onBodyEnteredEventHandler(p)));
    }

    private void _onBodyEnteredEventHandler(Player player)
    {
        player.Velocity = Vector2.Zero;
        player.GlobalPosition = player.StartMarker.GlobalPosition;
    }
}