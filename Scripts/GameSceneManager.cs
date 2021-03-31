using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour {

    public Animator transitionAnim;

    void Update() {
        if (!transitionAnim)
        {
            transitionAnim = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        }
    }

	public void ChangeScenes(string gameSceneName)
    {
        StartCoroutine("ChangeScene", gameSceneName);
    }

    IEnumerator ChangeScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
        Cursor.visible = true;
    }
	 
}
