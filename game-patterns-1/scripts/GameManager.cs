using Godot;

public partial class GameManager : Node
{
	public static GameManager Instance;
	public float HighScore = 999999f;
	private const string SavePath = "user://highscore.save";
	
	public override void _Ready()
	{
		if (Instance != null)
		{
			QueueFree();
			return;
		}
		Instance = this;
		LoadScore();
	}
	public void SaveScore()
	{
		using var file = FileAccess.Open(
			SavePath,
			FileAccess.ModeFlags.Write
		);
		if (file != null)
		{
			file.StoreFloat(HighScore);
		}
	}

	public void LoadScore()
	{
		if (!FileAccess.FileExists(SavePath))
			return;

		using var file = FileAccess.Open(
			SavePath,
			FileAccess.ModeFlags.Read
		);

		if (file != null)
		{
			HighScore = file.GetFloat();
		}
	}

	public void TrySetScore(float value)
	{
		if (value < HighScore)
		{
			HighScore = value;
			SaveScore();
		}
	}

	public void ClearScore()
	{
		HighScore = 999999f;
		SaveScore();
	}

	public void QuitGame()
	{
		GetTree().Quit();
	}
}
