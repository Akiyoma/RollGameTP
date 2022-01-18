using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlatforms : MonoBehaviour {
    public ScoreScript scoreScript;
    public bool start = false;
    
    public float playerDistanceSpawn = 20f;

    public Transform platformStart;
    public List<Transform> platforms;

    public GameObject player;

    private Transform lastPos;
    
    private void Awake() {
        lastPos = platformStart.Find("EndPosition");

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++) {
            SpawnPlatform();
        }
    }

    private void Update() {
        Debug.Log(lastPos);
        if (Vector2.Distance(player.transform.position, lastPos.position) < playerDistanceSpawn) {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform() {
        Transform chosenPlatform = platforms[Random.Range(0, platforms.Count)];
        Transform lastPlatformTransform = SpawnPlatform(chosenPlatform, lastPos.position);
        lastPos = lastPlatformTransform.Find("EndPosition");
    }
    
    private Transform SpawnPlatform(Transform platform, Vector2 spawnPosition) {
        Vector2 pos = new Vector2(Random.Range(4, 6), Random.Range(-3, 2));
        Transform platformTransform = Instantiate(platform, spawnPosition + pos, Quaternion.identity);
        PlatformScript platformScript = platformTransform.GetComponent<PlatformScript>();
        platformScript.spawnPlatforms = this;
        return platformTransform;
    }
}
