using Godot;
using System.Collections.Generic;

public partial class LevelManager : Node
{
	private Node currentLevel;
	
	private Dictionary<int, PackedScene> levels = new() 
	{
		{0, GD.Load<PackedScene>("res://scenes/Menu.tscn")},
		{1, GD.Load<PackedScene>("res://scenes/Game.tscn")},
		{2, GD.Load<PackedScene>("res://scenes/Options.tscn")},
	};
	
	public override void _Ready()
	{
		LoadLevel(0);
	}
	
	public void LoadLevel(int levelIndex)
	{
		if (currentLevel != null)
		{
			currentLevel.QueueFree();
		}
		
		PackedScene packedScene = levels[levelIndex];
		currentLevel = packedScene.Instantiate();
		AddChild(currentLevel);
		
		if (currentLevel is Menu menu)
		{
			menu.SetLevelManager(this);
		}
		
		if (currentLevel is Gameplay gameplay)
		{
			gameplay.SetLevelManager(this);
		}
		
		if (currentLevel is Options options)
		{
			options.SetLevelManager(this);
		}
	}
}
