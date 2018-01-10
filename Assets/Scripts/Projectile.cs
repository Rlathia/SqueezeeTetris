using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Projectile : MonoBehaviour {

	private Transform _transform;
	public Vector2 _currentSpeed;
	public Vector2 _currentPosition;

	void Start(){
		_currentSpeed = new Vector2 (0,(float)0.4);
		_transform = gameObject.GetComponent<Transform> ();
	}

	void Update(){
		_currentPosition = _transform.position;
		_currentPosition += _currentSpeed;

		//checking bounds of water
		if (_currentPosition.y >= 20)
		{
			Destroy(gameObject);
		}
		_transform.position = _currentPosition;
	}

	//collision method is invoked when fireball collides
	public void OnTriggerEnter2D(Collider2D other)
	{
		//if fireball collides with mud block, player gets extra 50 points
		//fireball and mud block are destroyed
		if (other.gameObject.tag.Equals("MudBlock"))
		{
			Debug.Log ("Fireball with MudBlock");
			FindObjectOfType<GameController>().Score += 50;
			other.gameObject.GetComponent<TetrisController> ().Reset ();
		}
	}
}