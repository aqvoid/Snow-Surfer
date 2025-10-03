using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private LevelProgressionUI levelProgressionCanvas;
    [SerializeField] private GameObject dinoSprite;
    [SerializeField] private GameObject frogSprite;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        levelProgressionCanvas.BeginGame();
    }

    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        levelProgressionCanvas.BeginGame();
    }
}
