using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
    public GameObject textUI;
    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        StartCoroutine(EndMessage());
    }
    
    IEnumerator EndMessage()
    {
        textUI.SetActive(true);
        yield return new WaitForSeconds(5);
        textUI.SetActive(false);
        SceneManager.LoadScene("LevelScene");
    }
}
