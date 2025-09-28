using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private PowerupSO powerupSO;
    [SerializeField] private PlayerController playerController;

    private SpriteRenderer powerupSprite;

    private void Awake()
    {
        powerupSprite = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && powerupSprite.enabled)
        {
            powerupSprite.enabled = false;
            playerController.ActivatePowerup(powerupSO);
        } 
    }
}
