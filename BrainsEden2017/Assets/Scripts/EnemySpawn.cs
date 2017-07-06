using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject [] enemy;                
    public float spawnTime = 3f;            
    public GameObject[] spawnPoints;
    
    private GameObject spawnType;

    private int enemyType;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        enemyType = Random.Range(0, 2);

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        spawnType = (GameObject)Instantiate(enemy[enemyType], spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);       
    }

}