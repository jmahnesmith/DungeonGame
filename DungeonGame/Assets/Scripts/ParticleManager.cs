using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    #region Singleton
    public static ParticleManager _instance;
    public static ParticleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ParticleManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("ParticleManager");
                    _instance = container.AddComponent<ParticleManager>();
                }
            }

            return _instance;
        }
    }
    #endregion
    public List<ParticleSystem> particleSystems;

    public enum ParticleEnum
    {
        ExplosionParticle1,
        HitParticleSmall,
        HitParticleMedium

    }

    public void PlayParticle(Vector3 Location, ParticleEnum ParticleName)
    {
        ParticleSystem particle = particleSystems.Find(x => x.name.Contains(ParticleName.ToString()));
        ParticleSystem spawnedParticle = Instantiate(particle, Location, Quaternion.identity);
        Destroy(spawnedParticle.gameObject, 1f);
        
        //Debug.Log("Particle Spawned.");
    }
}
