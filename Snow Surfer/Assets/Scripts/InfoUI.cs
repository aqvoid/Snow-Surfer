using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [Header("=== Texts ===")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI flipsText;
    [SerializeField] TextMeshProUGUI currentLevelText;

    private int totalScore;
    private int totalFlips;

    private void Start() => UpdateLevelText();

    private void ChangeScoreText() => scoreText.text = $"Score: {totalScore}";
    private void ChangeFlipsText() => flipsText.text = $"Flips: {totalFlips}";

    private void UpdateLevelText() => currentLevelText.text = $"Level: {LevelManager.Instance.CurrentLevelIndex + 1}";

    public void AddFlips(int flipsAdded)
    {
        totalFlips += flipsAdded;
        ChangeFlipsText();
    }

    public void AddScore(int scoreAdded)
    {
        totalScore += scoreAdded;
        ChangeScoreText();
    }
}
