using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionEffect;

    private GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindAnyObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(collisionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
