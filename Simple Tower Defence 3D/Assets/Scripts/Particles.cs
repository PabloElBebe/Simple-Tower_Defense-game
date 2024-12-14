using UnityEngine;

public class Particles : MonoBehaviour
{
    private CombatBuilding _building;

    public void Init(CombatBuilding building)
    {
        _building = building;
        gameObject.SetActive(false);
    }
    
    public void Play(Vector3 playPos)
    {
        gameObject.SetActive(true);
        transform.position = playPos;
        GetComponent<ParticleSystem>().Play();
    }

    public void StopPlaying()
    {
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (GetComponent<ParticleSystem>().isStopped)
            StopPlaying();
    }
}
