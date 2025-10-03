using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private int delay = 1;
    
    private ParticleSystem finishParticles;
    private bool triggered = false;

    private void Awake()
    {
        finishParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && !triggered)
        {
            triggered = true;
            finishParticles.Play();
            Invoke("LoadNext", delay);
        }
    }

    private void LoadNext() => LevelManager.Instance.LoadNextLevel();
}
