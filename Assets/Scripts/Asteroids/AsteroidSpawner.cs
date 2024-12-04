using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] Asteroids;
    public float SpawnDelay = 10.0f;
    public float SpawnRadius = 20.0f;
    private float _spawnDelay;
    private float _speedModifier = 1.0f;

    private void Update()
    {
        _spawnDelay -= Time.deltaTime;
        if (_spawnDelay <= 0)
            Spawn();

        IncreaseDifficulty();
    }

    private void Spawn()
    {
        _spawnDelay = SpawnDelay;
        int idx = Random.Range(0, Asteroids.Length);

        GameObject asteroid = Instantiate(Asteroids[idx]);
        asteroid.transform.position = transform.position + Random.onUnitSphere * SpawnRadius;

        asteroid.GetComponent<Asteroid>().Speed *= _speedModifier;
    }

    private void IncreaseDifficulty() 
    {
        SpawnDelay -= Time.deltaTime * Time.deltaTime;
        SpawnDelay = Mathf.Max(0.15f, SpawnDelay);

        _speedModifier += Time.deltaTime * Time.deltaTime;
        _speedModifier = Mathf.Min(_speedModifier, 3);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, SpawnRadius);
    }
}
