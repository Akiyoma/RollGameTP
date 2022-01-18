using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {
    public SpawnPlatforms spawnPlatforms;
    
    public float speed = 4f;
    
    private void Update() {
        if (spawnPlatforms.start) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (transform.position.x <= -20) {
            Destroy(gameObject);
        }
    }
}
