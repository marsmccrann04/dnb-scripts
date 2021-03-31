using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    GameSceneManager sceneManager;

    private static GameManagerScript _instance = null;
    public static GameManagerScript Instance
    {
        get
        {
            if(!_instance) {
                _instance = FindObjectOfType<GameManagerScript>();
                if (!_instance)
                {
                    GameObject go = new GameObject("_GameManager");
                    go.AddComponent<GameManagerScript>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    public bool gameOver;

    void Awake()
    {
        if(!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneManager = GetComponent<GameSceneManager>();
    }

    void Update()
    {
        if (gameOver)
        {
            ScoreManager.Instance.ClearScore();
            gameOver = false;
        }
    }
	
   
}
