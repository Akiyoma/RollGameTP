using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour {
    private TextMeshProUGUI scoreUI;
    private int score;

    private void Start() {
        scoreUI = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore() {
        score += 100;
        scoreUI.text = "Score : " + score;
    }
}
