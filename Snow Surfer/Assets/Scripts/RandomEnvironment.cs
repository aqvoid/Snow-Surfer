using UnityEngine;

public class RandomEnvironment : MonoBehaviour
{
    [SerializeField] EnvironmentSO environmentSO;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.sortingOrder = -15;
        spriteRenderer.sprite = environmentSO.GetRandomSprite();
    }
}
