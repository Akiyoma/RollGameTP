using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinLevel : MonoBehaviour {
    public void LoadLevel() {
        SceneManager.LoadScene("MainScene");
    }
}
