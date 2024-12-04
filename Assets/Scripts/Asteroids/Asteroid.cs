using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Health;
    public float Score;
    private float _maxHealth;

    public float Speed = 15.0f;

    public GameObject DeathParticle;
    public AudioClip DeathSound;
    private AudioSource _audioSource;

    [SerializeField]
    private Gradient _asteroidColor;
    private Material _asteroidMat;
    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _asteroidMat = GetComponent<Renderer>().material;
        _maxHealth = Health;

        _asteroidMat.SetColor("_Color", _asteroidColor.Evaluate(1));
    }

    private void Update()
    {
        transform.position += Time.deltaTime * Speed * Vector3.back;
    }

    public void DoDamage(float damage) 
    {
        Health -= damage;
        _asteroidMat.SetColor("_BaseColor", _asteroidColor.Evaluate(Health / _maxHealth));

        if (Health <= 0) 
        {
            Instantiate(DeathParticle, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(DeathSound);
            ScoreManager.Instance.AddScore(Score);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        collision.gameObject.GetComponent<PlayerHealth>().Kill();
    }
}
