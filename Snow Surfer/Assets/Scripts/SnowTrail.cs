using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    private ParticleSystem snowParticles;
    private int layerIndex;

    private void Awake()
    {
        snowParticles = transform.Find("Snow Particles").GetComponent<ParticleSystem>();
        layerIndex = LayerMask.NameToLayer("Floor");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerIndex) snowParticles.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerIndex) snowParticles.Stop();
    }
}
