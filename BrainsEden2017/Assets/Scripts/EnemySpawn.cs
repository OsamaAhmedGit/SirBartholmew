using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject [] enemy;                
    public float spawnTime = 3f;            
    public GameObject[] spawnPoints;

    public GameObject SmokeAnim;

    private GameObject smoke;
    
    private GameObject spawnType;

    private int enemyType;
    private int spawnPointIndex;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        enemyType = Random.Range(0, 2);

        // Find a random index between zero and one less than the number of spawn points.
        spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        smoke = (GameObject)Instantiate(SmokeAnim, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
        spawnType = (GameObject)Instantiate(enemy[enemyType], spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);

        Destroy(smoke, 0.5f);  
    }
}