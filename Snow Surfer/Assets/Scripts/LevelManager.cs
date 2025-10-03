using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int CurrentLevelIndex { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FinalMessage()
    {
        // Here should be final message: You completed the game, thank you
        
    }

    public void RestartLevel() => SceneManager.LoadScene(CurrentLevelIndex);
    public void LoadNextLevel()
    {
        int nextScene = CurrentLevelIndex+1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            CurrentLevelIndex = nextScene;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            FinalMessage();
        }

    }
}
