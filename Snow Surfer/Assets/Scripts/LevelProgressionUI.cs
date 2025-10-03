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
        if (currentLevelText.isActiveAndEnabled) currentLevelText.gameObject.SetActive(false);
        if (!characterSelectionCanvas.activeInHierarchy) characterSelectionCanvas.SetActive(true);
        if (finishPanel.activeInHierarchy) finishPanel.SetActive(false);
        if (scoreCanvas.activeInHierarchy) scoreCanvas.SetActive(false);
    }

    public void BeginGame()
    {
        if (characterSelectionCanvas.activeInHierarchy) characterSelectionCanvas.SetActive(false);
        if (!currentLevelText.isActiveAndEnabled) currentLevelText.gameObject.SetActive(true);
        if (!scoreCanvas.activeInHierarchy) scoreCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        if (!finishPanel.activeInHierarchy) finishPanel.SetActive(true);
        if (currentLevelText.isActiveAndEnabled) currentLevelText.gameObject.SetActive(false);
        if (scoreCanvas.activeInHierarchy) scoreCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void QuitGame() => Application.Quit();
    public void RestartGame() => SceneManager.LoadScene(1);
}
