using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [SerializeField] GameManagerScript gameManager;

    private static ScoreManager _instance = null;
    public static ScoreManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if (!_instance)
                {
                    GameObject go = new GameObject("_ScoreManager");
                    _instance = go.AddComponent<ScoreManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    int score = 0; // the score itself
    int finalScore = 0;

    void Awake()
    {
        if (!_instance) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

	public int GetScore()
    {
        return score;
    }

    public string GetFinalScore()
    {
        return finalScore.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        AudioManager.Instance.PlaySound("game_score");
    }

    public void DecreaseScore (int scoreToSubtract)
    {
        // if score is 0, keep it zero
        int total = score - scoreToSubtract;
        if (total < 0) {
            score = 0;
        } else {
            score -= scoreToSubtract;
        }

    }

    public void ClearScore()
    {
        score = 0;
    }

    // makes the curr score, the final score
    public void AddFinalScore()
    {
        finalScore = score;
    }


	 
}
