using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destoryEffect;
    [SerializeField] private int hitPoints = 3;
    private void OnParticleCollision(GameObject other)
    {
        ProcessCollision();
    }

    private void ProcessCollision()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
