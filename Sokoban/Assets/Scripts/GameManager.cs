using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject[] slots;
    public MoveBlock[] blocks;
    public PlayerController playerController;

    public GameObject winUI;

    public int count;

    private void Start() {
        count = 0;
        
        foreach (MoveBlock block in blocks) {
            block.gameManager = this;
        }
    }

    public void Update() {
        if (count == slots.Length) {
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        winUI.SetActive(true);
        yield return new WaitForSeconds(3);
        winUI.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void AddCount() {
        count++;
    }

    public void ReduceCount() {
        count--;
    }

    public void RestartLevel() {
        SceneManager.LoadScene("MainScene");
    }

    public void Undo() {
        if (playerController.previousPos.Count > 0) {

            foreach (MoveBlock block in blocks) {
                block.transform.position = block.previousPos[block.previousPos.Count - 1];
                block.previousPos.RemoveAt(block.previousPos.Count - 1);
            }

            playerController.transform.position = playerController.previousPos[playerController.previousPos.Count - 1];
            playerController.previousPos.RemoveAt(playerController.previousPos.Count - 1);
        }
    }

    public void AddPreviousPos(MoveBlock block, Vector3 normal) {
        foreach (MoveBlock _block in blocks) {
            _block.previousPos.Add(_block.transform.position);
        }
        
        playerController.previousPos.Add(block.transform.position + normal);
    }
}
