using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private GameObject dinoSprite;
    [SerializeField] private GameObject frogSprite;

    private void Start() => Time.timeScale = 0;

    private void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }
}
