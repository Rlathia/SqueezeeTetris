using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	private Transform _transform;
	private Vector2 _currentPos;
	private float mousePosInBlocks;	
	private float turretSource = 0;
	public GameObject Bullet;
	public GameObject waterSpawn;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//mousePosInBlocks = Input.mousePosition.x / Screen.width;
		//Debug.Log("mouse position :" + mousePosInBlocks);
		rotate_turretHead ();
		fire_turret (turretSource);
	}

	//shoot water from the turret
	void fire_turret(float turretSource){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space");
			//shot water from all turrets
			GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
			//Destroy (clone, 10.0f);
		}
	}

	//rotation of Turret head
	void rotate_turretHead(){

		if (Input.GetKey (KeyCode.D)) {
			_transform.Rotate(0, 0, -70 * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.A)) {
			_transform.Rotate(0, 0, 70 * Time.deltaTime);
		}
	}
}