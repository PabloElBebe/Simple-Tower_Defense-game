using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyParticlesPool : CustomPool<Particles>
{
    private GameObject _particlesPrefab;
    private Transform _parent;
    
    public DestroyParticlesPool(GameObject particles, Transform parent, int objectsAmount)
    {
        _particlesPrefab = particles;
        _parent = parent;
        Objects = new List<Particles>();

        for (int i = 0; i < objectsAmount; i++)
        {
            Particles currentParticles = GameObject.Instantiate(particles, parent).GetComponent<Particles>();
            Objects.Add(currentParticles);
        }
    }

    public override Particles Get()
    {
        Particles currentParticles = Objects.FirstOrDefault(obj => !obj.isActiveAndEnabled);

        if (currentParticles == null)
            currentParticles = Create();
        
        return currentParticles;
    }

    public override void Release(GameObject obj)
    {
        obj.GetComponent<Particles>().StopPlaying();
    }

    public override Particles Create()
    {
        Particles currentParticles = GameObject.Instantiate(_particlesPrefab, _parent).GetComponent<Particles>();
        Objects.Add(currentParticles);
        return currentParticles;
    }
}
