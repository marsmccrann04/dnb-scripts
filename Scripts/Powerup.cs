using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    int powerUpNum;
    bool powerUpUsed = false;

    PlayerBullets playerBullets;

    [SerializeField] Animator powerUpAnim;

    float elapsedTime = 6f;

    void OnEnable() {
        playerBullets = FindObjectOfType<PlayerBullets>();
        powerUpAnim.SetInteger("use", 0);
        powerUpUsed = false;
        powerUpAnim.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        elapsedTime = 6f;
    }

    public void UsePowerUp() {

        powerUpNum = Random.Range(1, 8);

        if (powerUpNum == 1 || powerUpNum == 2 || powerUpNum == 3) {
            playerBullets.AddBullets(5);
        } else if (powerUpNum == 5 || powerUpNum == 5) {
            ScoreManager.Instance.AddScore(50);
        } else if (powerUpNum == 6 || powerUpNum == 7) {
            playerBullets.DecreaseBullets(3);
        } else {
            ScoreManager.Instance.AddScore(50);
        }

        powerUpUsed = true;

    }

    void Update()
    {
        // Make Powerup appear for 6 seconds
        // When 6 seconds is done, then disappear
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0f) {
            powerUpUsed = true;
        }
        
        if (powerUpUsed) {
            StartCoroutine("UsePowerUpAnim");
        }
        
    }
    
    IEnumerator UsePowerUpAnim()
    {
        powerUpAnim.SetInteger("use", 1);
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);    
    }
 
    
     
}
