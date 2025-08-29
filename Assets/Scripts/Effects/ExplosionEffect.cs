using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ExplosionEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        _particleSystem.Play();
        Destroy(gameObject, _particleSystem.main.duration);
    }
}