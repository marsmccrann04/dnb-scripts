using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHit : MonoBehaviour {

	void OnEnable () {
        StartCoroutine(DuckHitAction());
	}
	 
	IEnumerator DuckHitAction() {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
