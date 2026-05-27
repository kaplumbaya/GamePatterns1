using Godot;

public partial class Menu : Control
{
	private LevelManager levelManager;
	private Label highscoreLabel;
	
	public void SetLevelManager(LevelManager manager)
	{
		levelManager = manager;
	}
	
	public override void _Ready()
	{
		highscoreLabel =
			GetNode<Label>("VboxContainer/HighScoreLabel");
			
		highscoreLabel.Text =
			"Best Time: " +
			GameManager.Instance.HighScore.ToString("0.000");
	}
	
	private void OnPlayButtonPressed()
	{
		levelManager.LoadLevel(1);
	}
	
	private void OnOptionsButtonPressed()
	{
		levelManager.LoadLevel(2);
	}
	
	private void OnExitButtonPressed()
	{
		GameManager.Instance.QuitGame();
	}
}
