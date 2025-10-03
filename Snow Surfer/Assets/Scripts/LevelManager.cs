using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int CurrentLevelIndex { get; private set; }

    private LevelProgressionUI levelUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            levelUI = FindAnyObjectByType<LevelProgressionUI>();
        }
        else
        {
            Destroy(gameObject);
        }
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
            levelUI.EndGame();
        }

    }
}
