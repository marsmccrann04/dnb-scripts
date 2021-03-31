using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _FinalScoreDisplay : MonoBehaviour {

    [SerializeField] TextMeshProUGUI finalScoreText;
	 
	void Update () {
        finalScoreText.text = ScoreManager.Instance.GetFinalScore();
	}
}
