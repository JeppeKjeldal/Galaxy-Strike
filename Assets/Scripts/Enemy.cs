using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destoryEffect;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destoryEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
