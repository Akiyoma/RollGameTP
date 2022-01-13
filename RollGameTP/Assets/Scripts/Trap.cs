using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    public GameObject ballPrefab;
    
    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        GameObject.Find("Map").transform.rotation = Quaternion.identity;
        
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.position = GameObject.Find("Spawn").transform.position + new Vector3(0, 2, 0);
    }
}
