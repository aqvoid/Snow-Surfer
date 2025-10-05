using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUI : MonoBehaviour
{
    public void QuitGame() => Application.Quit();
    public void RestartGame() => LevelManager.Instance.RestartWholeGame();

}
