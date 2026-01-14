using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem collisionEffect;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(collisionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
