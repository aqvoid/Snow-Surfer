using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private int restartDelay = 1;
    
    private ParticleSystem finishParticles;

    private void Awake()
    {
        finishParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            finishParticles.Play();
            Invoke("NextScene", restartDelay);
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
