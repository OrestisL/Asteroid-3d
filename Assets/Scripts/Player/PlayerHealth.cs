using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject DeathParticle;
    public AudioSource Source;
    public AudioClip DeathSound;
    public void Kill() 
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        Source.PlayOneShot(DeathSound);
        // show ui
        ScoreManager.Instance.ShowFinalScore();

        Destroy(gameObject);
    }
}
