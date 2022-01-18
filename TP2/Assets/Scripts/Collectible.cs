using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    public PlatformScript platformScript;
    
    private void OnTriggerEnter2D(Collider2D other) {
        platformScript.spawnPlatforms.scoreScript.AddScore();
        Destroy(gameObject);
    }
}
