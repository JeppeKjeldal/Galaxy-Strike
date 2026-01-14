using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with object: {other.gameObject.name}");
    }
}
