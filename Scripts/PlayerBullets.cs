using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {

    [SerializeField] GameSceneManager sceneManager;

    int bullets = 25;
    bool hasBullets = true;

    // Function to check if there is still bullets
    public bool HasBullets() {
        if (bullets > 0)
            return true;

        return false;
    } 

    // Function to add bullets (via powerup)
    public void AddBullets(int bulletsToAdd) {
        bullets += bulletsToAdd;
    }
    
    // Function to decrease bullets
    public void DecreaseBullets() {
        bullets -= 1;
    }

    public void DecreaseBullets(int bulletsToSubtract) {
        bullets -= bulletsToSubtract;
    }

    public int GetBullets()
    {
        return bullets;
    }

    void Update() {

        if (bullets <= 0) {
            bullets = 0;
            hasBullets = false;
        }
        
        if(!hasBullets)
        {
            hasBullets = true;
            Cursor.visible = true;
            ScoreManager.Instance.AddFinalScore();
            GameManagerScript.Instance.gameOver = true;
            sceneManager.ChangeScenes("gameover_scene");
            AddBullets(25);
        }    
    }


         
}
