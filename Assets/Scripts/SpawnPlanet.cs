using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanet : MonoBehaviour {
    public List<Transform> prefabs = new List<Transform>();
    public Transform spawnPositionBottom;
    public Transform spawnPositionTop;
    public Transform target;
    public float spawnRate;
    public float forceMultiplier = 2f;
    public float difficultyRate = 10f;

    private float difficulty = 1;
    private float lastDifficultyTime = 0f;
    private float lastSpawnTime = 0f;

    void Update () {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            Spawn();
            lastSpawnTime = Time.time;
        }
        if(Time.time - lastDifficultyTime > difficultyRate)
        {
            difficulty += 0.01f;
            lastDifficultyTime = Time.time;
            Debug.Log(difficulty + " = zorluk");
        }
	}

    private void Spawn()
    {
        float randomX = Random.Range(spawnPositionBottom.localPosition.x, spawnPositionTop.localPosition.x);
        float randomY = Random.Range(spawnPositionBottom.localPosition.y, spawnPositionTop.localPosition.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY , 0);
        Vector3 direction = (target.position - spawnPosition) * forceMultiplier;


        Transform prefabForSpawn = prefabs[Random.Range(0 , prefabs.Count)];
        Transform spawnedPlanet = Instantiate(prefabForSpawn, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = spawnedPlanet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * rb.mass * difficulty);
    }
}
