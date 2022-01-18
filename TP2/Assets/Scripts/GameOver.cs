using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject gameOverUI;
    
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(ReloadLevel());
    }
    
    IEnumerator ReloadLevel()
    {
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainScene");
    }
}
