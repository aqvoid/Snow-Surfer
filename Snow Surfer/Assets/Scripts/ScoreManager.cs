using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("=== Texts ===")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI flipsText;

    private int totalScore;
    private int totalFlips;

    private void ChangeScoreText() => scoreText.text = $"Score: {totalScore}";
    private void ChangeFlipsText() => flipsText.text = $"Flips: {totalFlips}";

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
