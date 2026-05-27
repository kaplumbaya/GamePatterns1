using Godot;
using System;

public partial class Gameplay : Node3D
{
	private LevelManager levelManager;
	private Label timerLabel;
	private float timer = 5f;
	private bool gameOver = false;
	
	public void SetLevelManager(LevelManager manager)
	{
		levelManager = manager;
	}
	
	public override void _Ready()
	{
		timerLabel = GetNode<Label>("TimerLabel");
	}

	public override void _Process(double delta)
	{
		if (gameOver)
			return;
			
		timer -= (float)delta;
		timerLabel.Text = timer.ToString("0.000");
		
		if (timer <= 0)
		{
			gameOver = true;
			levelManager.LoadLevel(0);
		}
	}
	
	public override void _Input(InputEvent @event)
	{
		if (gameOver)
			return;
			
		if (@event.IsActionPressed("ui_accept"))
		{
			float score = Mathf.Abs(timer);
			GameManager.Instance.TrySetScore(score);
			gameOver = true;
			levelManager.LoadLevel(0);
		}
	}
}
