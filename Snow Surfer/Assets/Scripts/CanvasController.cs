using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("=== Canvases ===")]
    [SerializeField] InfoUI infoCanvas;
    [SerializeField] CharacterSelectionManager characterSelectionCanvas;
    [SerializeField] FinishUI finishCanvas;

    private void Start()
    {
        Time.timeScale = 0f;

        characterSelectionCanvas.gameObject.SetActive(true);
        infoCanvas.gameObject.SetActive(false);
        finishCanvas.gameObject.SetActive(false);
    }

    public void BeginGame()
    {
        Time.timeScale = 1f;

        characterSelectionCanvas.gameObject.SetActive(false);
        infoCanvas.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        infoCanvas.gameObject.SetActive(false);
        finishCanvas.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }
}
