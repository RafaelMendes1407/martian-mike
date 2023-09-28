using Godot;

namespace MartianMike.Scripts;

public partial class Start : StaticBody2D
{
	private Marker2D _spawnPosition;
	public override void _Ready()
	{
		this._spawnPosition = this.GetNode<Marker2D>("SpawnPosition");
	}
	
	public Marker2D GetSpawnPosition()
	{
		return this._spawnPosition;
	}	
}