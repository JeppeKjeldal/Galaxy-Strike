using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destoryEffect;
    [SerializeField] private int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    private Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessCollision();
    }

    private void ProcessCollision()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destoryEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
