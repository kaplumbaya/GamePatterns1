using Godot;

public partial class Options : Control
{
	private LevelManager levelManager;
	
	public void SetLevelManager(LevelManager manager)
	{
		levelManager = manager;
	}
	
	private void OnClearButtonPressed()
	{
		GameManager.Instance.ClearScore();
	}
	
	private void OnBackButtonPressed()
	{
		levelManager.LoadLevel(0);
	}
}
