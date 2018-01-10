using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] tetrisObjects;
	// Use this for initialization
	void Start () {
		spawnRandom ();
	}
	
	public void spawnRandom(){
		int index = Random.Range (0, tetrisObjects.Length);
		Instantiate (tetrisObjects [index], transform.position, Quaternion.identity);
	}
}
