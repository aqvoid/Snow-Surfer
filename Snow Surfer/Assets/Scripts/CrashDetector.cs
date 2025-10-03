using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private int restartDelay = 1;

    private PlayerController playerController;
    private ParticleSystem crashParticles;

    private void Awake()
    {
        crashParticles = transform.Find("Crash Particles").GetComponent<ParticleSystem>();
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            playerController.DisableControls();
            crashParticles.Play();
            Invoke("ReloadScene", restartDelay);
        }
    }

    private void ReloadScene()
    {
        LevelManager.Instance.RestartLevel();
    }
}
