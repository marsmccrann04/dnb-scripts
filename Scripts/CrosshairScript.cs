using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

    Vector3 mousePos;
    Vector2 mousePos2d;

    Ray ray;
    RaycastHit2D hit;

    PlayerBullets playerBullets;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] DuckHitSpawner hitSpawner;

    void Start () {
        playerBullets = GetComponent<PlayerBullets>();
	}

	void Update () {

        Cursor.visible = false;

        // Gets mouse position for crosshair position
        mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        mousePos2d = new Vector2(mousePos.x, mousePos.y);

        // Make crosshair follow mouse
        transform.position = mousePos2d;

        // If on mouseclick, the mousepos is within a collider via raycast
        // and player still has bullets
        if(Input.GetMouseButtonDown(0) && playerBullets.HasBullets()) {

            hit = Physics2D.Raycast(mousePos2d, Vector2.zero);

            if (hit.collider != null) {

                // If a powerup is hit, use it
                if (hit.collider.GetComponent<Powerup>() != null) {
                    hit.collider.GetComponent<Powerup>().UsePowerUp();
                    AudioManager.Instance.PlaySound("powerup_pickup", 0.5f);
                }
                    
                // If a duck is hit, decrease it's health
                if (hit.collider.GetComponent<DuckHealth>() != null) {
                    hit.collider.GetComponent<DuckHealth>().DecreaseHealth();

                    GameObject duckHit = hitSpawner.GetAvailableObject();
                    if (duckHit) {
                        AudioManager.Instance.PlaySound("ball_shoot", 0.5f);
                        duckHit.transform.position = transform.position;
                        duckHit.SetActive(true);
                    }
                    
                }
                
            }

            // Per shot of the player, decrease bullet by one
            playerBullets.DecreaseBullets();
        }  

    }
 
}
