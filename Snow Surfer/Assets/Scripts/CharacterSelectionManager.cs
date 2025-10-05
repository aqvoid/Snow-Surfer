using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    [Header("=== References ===")]
    [SerializeField] private CanvasController canvasController;

    [Header("=== Sprites ===")]
    [SerializeField] private GameObject dinoSprite;
    [SerializeField] private GameObject frogSprite;

    private void Start()
    {
        dinoSprite.SetActive(false);
        frogSprite.SetActive(false);
    }
    

    private void ActivateCharacterSprite(GameObject character)
    {
        character.SetActive(true);
        canvasController.BeginGame();
    }

    public void ChooseDinoButton() => ActivateCharacterSprite(dinoSprite);

    public void ChooseFrogButton() => ActivateCharacterSprite(frogSprite);
}
