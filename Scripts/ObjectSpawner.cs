using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    List<GameObject> objects;
    [SerializeField] GameObject obj;

    float spawnDuration = 1f;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] int amountOfObjects;

    [SerializeField] bool SpawnAtRandomPos = false;
    [SerializeField] float randX;
    [SerializeField] float randY;

    void Start () {

        // Create list of objects and fill them in acrdng to amount
        objects = new List<GameObject>();

        for (int i = 0; i < amountOfObjects; i++) {
            objects.Add(Instantiate(obj, transform.position, transform.rotation));
            objects[i].SetActive(false);
        }

        InvokeRepeating("SpawnObjects", spawnDuration, spawnDelay);

	}
	 
	void SpawnObjects() {

        // For each object in the list, check if not active in hierarchy
        // If not active, make active and set pos depending on condition
        foreach (var objt in objects) {
            if (!objt.activeInHierarchy) {
                
                // set spawn pos to the given randx and randy values
                if (SpawnAtRandomPos) {
                    objt.transform.position = new Vector2(Random.Range(randX, -randX), Random.Range(randY, -randY));
                    objt.SetActive(true);
                    break;
                }

                // set obj to spawn pos
                objt.transform.position = transform.position;
                objt.transform.rotation = transform.rotation;
                objt.SetActive(true);
                break;
            }
        }
    }

    public GameObject GetAvailableObject()
    {
        foreach (var availObj in objects)
        {
            if (!availObj.activeInHierarchy)
            {
                return availObj;
            }
        }

        return null;
    }

   

}
