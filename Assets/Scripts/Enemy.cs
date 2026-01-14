using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyEffect;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
