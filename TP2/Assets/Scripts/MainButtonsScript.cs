using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonsScript : MonoBehaviour {
    public PlayerController player;
    public void StartLevel() {
        gameObject.SetActive(false);
        player.start = true;
    }

    public void BackToMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
