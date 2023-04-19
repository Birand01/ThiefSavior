using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodParticle;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerTakeDamageHandler += PlayBloodParticle;
    }

    private void PlayBloodParticle()
    {
        PlayParticle(bloodParticle);
    }
    private void PlayParticle(ParticleSystem particle)
    {
        particle.Play();
    }

    private void InstantiateParticle(ParticleSystem particle)
    {
        ParticleSystem newParticles =
            Instantiate(particle, transform.position, transform.rotation);
        newParticles.Play();
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerTakeDamageHandler -= PlayBloodParticle;
    }
}
