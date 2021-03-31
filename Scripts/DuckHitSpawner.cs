using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHitSpawner : MonoBehaviour {

    List<GameObject> hits;
    [SerializeField] GameObject hit;
    [SerializeField] int numOfHits; 

	void Start () {

        hits = new List<GameObject>();

        for (int i = 0; i < numOfHits; i++) {
            hits.Add(Instantiate(hit, transform.position, transform.rotation));
            hits[i].SetActive(false);
        }	
	}
	
	 
	public GameObject GetAvailableObject () {

        foreach (var hitObject in hits)
        {
            if(!hitObject.activeInHierarchy)
            {
                return hitObject;
            }
        }
        return null;
        
	}
}
