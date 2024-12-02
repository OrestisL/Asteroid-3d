using UnityEngine;

public class CleanupAsteroids : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Asteroid))
        {
            Destroy(collision.gameObject);
        }
    }
}
