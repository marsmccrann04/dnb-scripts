using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {

    public float moveSpeed = 2f;
    public float randX = 2f;
    public float randY = 1f;
    bool isLeft = true;


    // random speed added for gameplay difficulty
    float randomSpeedSeed;

    ScoreManager scoreManager;
    int currentScore;

	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        randomSpeedSeed = Random.Range(0.5f, 4f);
	}
	
	void Update () {

        if (transform.position.y >= 6) {
            scoreManager.DecreaseScore(100);
            GetComponent<DuckHealth>().DecreaseHealth(GetComponent<DuckHealth>().GetDuckHealth());
        }

        // Gets score to change duck speed as score gets higher
        currentScore = scoreManager.GetScore();
        if (currentScore <= 500) {
            moveSpeed = 2f;
        } else if (currentScore <= 1000) {
            moveSpeed = 2.5f;
        } else if (currentScore <= 1500) {
            moveSpeed = 3f;
        }
 
        // Duck Movement
        // Checks to see if it's current position is greater/less than 5 (middle)
        // and move in zig-zag patterns
        if (transform.position.x >= 5f && !isLeft) {
            randX = -1f;
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (transform.position.x <= -5f && isLeft) {
            randX = 1f;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (isLeft) {
            isLeft = false;
        } else if (!isLeft) {
            isLeft = true;
        }

        transform.Translate(new Vector2(randX, 0.1f) * (moveSpeed + randomSpeedSeed) * Time.deltaTime);

    }

    
}
