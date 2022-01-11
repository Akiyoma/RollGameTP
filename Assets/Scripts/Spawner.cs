using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject ballPrefab;
    
    void Start() {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.position = transform.position + new Vector3(0, 2, 0);
    }
}
