using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDScript : MonoBehaviour {

    PlayerBullets playerBullets;

    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] TextMeshProUGUI bulletsAmount;

    void Start() {
        playerBullets = FindObjectOfType<PlayerBullets>(); 
    }

    void Update() {

        // Display player score and amount of bullets
        playerScore.text = "SCORE: " + ScoreManager.Instance.GetScore().ToString();
        bulletsAmount.text = "x" + playerBullets.GetBullets().ToString();

    } 

}
