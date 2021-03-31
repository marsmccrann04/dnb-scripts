using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHealth : MonoBehaviour {

    int health = 1;
    int typeOfDuck = 1;

    void Start() {

        typeOfDuck = Random.Range(1, 3);
        health = typeOfDuck;

        // Scales size of duck according to duck type
        switch (typeOfDuck) {
            case 1:
                gameObject.transform.localScale = new Vector2(1f, 1f);
                break;
            case 2:
                gameObject.transform.localScale = new Vector2(1.3f, 1.3f);
                break;
            case 3:
                gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
                break;
            default:
                gameObject.transform.localScale = new Vector2(1f, 1f);
                break;
        }

    }

    void Update() {

        if (health <= 0) {
            health = typeOfDuck;
            ScoreManager.Instance.AddScore(typeOfDuck * 20);
            gameObject.SetActive(false);
        }

    }

    public void DecreaseHealth() {
        health -= 1;
    }

    public void DecreaseHealth(int amountOfHealth)
    {
        health -= amountOfHealth;
    }

    public int GetDuckHealth()
    {
        return health;
    }
    
     


}
