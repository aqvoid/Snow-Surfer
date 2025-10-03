using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressionUI : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject characterSelectionCanvas;
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] GameObject finishPanel;

    private void Start()
    {
        currentLevelText.text = $"Level: {LevelManager.Instance.CurrentLevelIndex}";
        characterSelectionCanvas.SetActive(true);
        currentLevelText.gameObject.SetActive(false);
        finishPanel.SetActive(false);
    }

    public void BeginGame()
    {
        characterSelectionCanvas.SetActive(false);
        currentLevelText.gameObject.SetActive(true);
        scoreCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        finishPanel.SetActive(true);
        currentLevelText.gameObject.SetActive(false);
        scoreCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void QuitGame() => Application.Quit();
    public void RestartGame() => SceneManager.LoadScene(1);
}
