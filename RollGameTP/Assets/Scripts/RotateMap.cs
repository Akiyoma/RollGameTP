using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour {
    public float speed = 30;
    
    void Update() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        transform.Rotate(Vector3.back * moveX * Time.deltaTime * speed);
        transform.Rotate(Vector3.right * moveY * Time.deltaTime * speed);
    }
}
