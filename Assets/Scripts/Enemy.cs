using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Enemy hit by particle system");
        Destroy(gameObject);
    }
}
