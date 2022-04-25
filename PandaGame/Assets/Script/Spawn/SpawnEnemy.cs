using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] asteroidPrefab;
    private Vector2[] positionSpawn;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;
    private Transform[] transformsSubObject;
    // Use this for initialization
    void Start()
    {
        transformsSubObject = GetComponentsInChildren<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
       
    }
    private void spawnEnemy()
    {
        
        int indexEnemyType = Random.Range(0, asteroidPrefab.Length); //random Enemy type  be spawned
        int numberSpawn = Random.Range(1, 4);
        //GameObject[] listEnemy = new GameObject[numberSpawn];
        List<GameObject> listEnemy = new List<GameObject>();
        int sideSpawn = Random.Range(1, 3); //1 - LEFT   || 2 - RIGHT [min, max)
       
        Vector3 spawnPosition = transformsSubObject[sideSpawn].position;
        for (int i=0; i<numberSpawn; i++)
        {
            GameObject enemy = Instantiate(asteroidPrefab[indexEnemyType]) as GameObject;
            
            if (sideSpawn == 1)
            {
                enemy.transform.localScale = new Vector3(-1, 1, 1); //Side LEFT - RIGHT
            }
            float height = enemy.GetComponent<BoxCollider2D>().size.y;
            enemy.transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 5.0f*i/6, enemy.transform.position.z);
            listEnemy.Add(enemy);
            
        }

        int t= listEnemy.Count;

        
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,respawnTime+1));
            spawnEnemy();
        }
    }
}
