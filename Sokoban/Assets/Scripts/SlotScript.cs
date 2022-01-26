using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour {
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Block")) {
            gameManager.AddCount();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Block")) {
            gameManager.ReduceCount();
        }
    }
}
