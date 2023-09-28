using Godot;

namespace MartianMike.Scripts.Commons.Baseclass;

public static class BasePlayer
{
    public static Player LoadBasePlayer(Marker2D startMarker, BaseLevel baseLevel)
    {
        var player = (Player) GD.Load<PackedScene>("res://scenes/player.tscn").Instantiate();
        baseLevel.AddChild(player);
        player.DefinePlayerPosition(startMarker);
        return player;
    }
}