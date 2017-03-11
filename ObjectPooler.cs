using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// - Source: https://www.raywenderlich.com/136091/object-pooling-unity
/// 
/// - Replace:
/// Instantiate (obj, whatever.transform.position, whatever.transform.rotation);
/// 
/// - By:
/// GameObject pooledObject = ObjectPooler.SharedInstance.GetPooledObject ();
/// if (pooledObject != null) {
///    pooledObject.transform.position = whatever.transform.position;
///    pooledObject.transform.rotation = whatever.transform.rotation;
///    pooledObject.SetActive (true);
/// }
/// 
/// - If you don't need the pooledObject anymore:
/// pooledObject.SetActive (false);
/// 
/// - Note that code placed on pooledObject's Start method must be moved to OnEnable. Start method is only called once after a script is enabled for the first time.
/// </summary>

public class ObjectPooler : MonoBehaviour {

	//##################################################
	//	PUBLIC FIELDS
	//##################################################
	public List <GameObject> pooledObjects;
	public GameObject objectToPool;
	public int amountToPool;


	//##################################################
	//	STATIC REFERENCES
	//##################################################
	public static ObjectPooler SharedInstance;


	//##################################################
	//	UNITY FUNCTIONS
	//##################################################
	// Use this for initialization
	void Start () {
		SharedInstance = this;

		pooledObjects = new List <GameObject> ();
		for (int i = 0; i < amountToPool; i++) {
			GameObject obj;

			obj = (GameObject)Instantiate (objectToPool);
			obj.SetActive (false); 
			pooledObjects.Add (obj);
		}
	}


	//##################################################
	//	ALVARO FUNCTIONS
	//##################################################
	public GameObject GetPooledObject () {
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects[i].activeInHierarchy) {
				return pooledObjects[i];
			}
		}
		return null;
	}

}
