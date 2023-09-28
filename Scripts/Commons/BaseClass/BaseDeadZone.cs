using Godot;

namespace MartianMike.Scripts.Commons.Baseclass;

public class BaseDeadZone
{
    
    
    public static void BuildDeadZone(Marker2D endLevelMarker, BaseLevel baseLevel)
    {
        DeadZone area2D = (DeadZone) GD.Load<PackedScene>("res://scenes/dead_zone.tscn").Instantiate();
        CollisionPolygon2D collisionPolygon2D = area2D.GetNode<CollisionPolygon2D>("CollisionPolygon2D");
        collisionPolygon2D.Polygon = _polygonPoints(endLevelMarker);
        baseLevel.AddChild(area2D);
    }

    private static Vector2[] _polygonPoints(Marker2D endLevelMarker)
    {
        return new Vector2[]
        { // 1329 - 288
            new Vector2(-150, 284),
            new Vector2(endLevelMarker.Position.X, 284),
            new Vector2(endLevelMarker.Position.X, 290),
            new Vector2(-150, 290)
        };
    }
}