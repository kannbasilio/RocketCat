using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float initialSpawnRate = 2f;
    public float spawnRateDecrease = 0.1f;
    public float initialMeteorSpeed = 5f;
    public float meteorSpeedIncrease = 0.1f;

    private float currentSpawnRate;
    private float currentMeteorSpeed;

    private bool playerStartedMoving = false;
    private bool isSpawning = false; // Flag to check if spawning is already in progress

    private GameTimer gameTimer;

    void Start()
    {
        // Initialize parameters
        currentSpawnRate = initialSpawnRate;
        currentMeteorSpeed = initialMeteorSpeed;

        // Find and store a reference to the GameTimer script
        gameTimer = FindObjectOfType<GameTimer>();
    }

    void Update()
    {
        // Start spawning meteors when the player starts moving
        if (playerStartedMoving && !isSpawning)
        {
            StartSpawning();
        }
    }

    void SpawnMeteor()
    {
        // Set a random Y position within a specified range
        float randomY = Random.Range(-4f, 4f);

        // Spawn a meteor at the spawner's position with the random Y position
        GameObject meteor = Instantiate(meteorPrefab, new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);

        // Set the meteor's speed
        MeteorMovement meteorMovement = meteor.GetComponent<MeteorMovement>();
        if (meteorMovement != null)
        {
            meteorMovement.SetSpeed(currentMeteorSpeed);
        }

        // Increase difficulty over time
        currentSpawnRate -= spawnRateDecrease;
        currentMeteorSpeed += meteorSpeedIncrease;
    }

    // Called when the player starts moving
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("SpawnMeteor", 0f, currentSpawnRate);
        }
    }
}

