using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : MonoBehaviour {

	float down = 0;
	public float downSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement_userInput ();
	}

	public void Reset(){
		Destroy (gameObject);
	}
		
	void movement_userInput(){

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//if right arrow is pressed, move 1 block right
			transform.position += new Vector3 (1, 0, 0);
			if (isValidGridPosition ()) {
				FindObjectOfType<Game>().updateGrid (this);
			} else
				transform.position += new Vector3 (-1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			//if left arrow is pressed, move 1 block left
			transform.position -= new Vector3 (1, 0, 0);
			if (isValidGridPosition ()) {
				FindObjectOfType<Game>().updateGrid (this);
			} else
				transform.position -= new Vector3 (-1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//if up arrow is pressed, rotate blocks by 90 degrees clockwise
			transform.Rotate (0, 0, 90);
			if (isValidGridPosition ()) {
				FindObjectOfType<Game>().updateGrid (this);
			} else {
				Debug.Log ("Block cannot rotate " + transform.position);
				transform.Rotate (0, 0, -90);
			}

		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Time.time - down >= 1) {
			//if down arrow is pressed, move 1 block down
			transform.position -= new Vector3 (0, 1, 0);
			if (isValidGridPosition ()) {
				FindObjectOfType<Game>().updateGrid (this);
			} else {
				transform.position -= new Vector3 (0, -1, 0);
				FindObjectOfType<Game> ().deleteRow ();
				// if block completes the column(column is full of blocks), call gameOver
				// else spawn new block and disable the existing one
				if (FindObjectOfType<Game> ().checkIsAtTop (this)) {
					Debug.Log ("Game over");
					FindObjectOfType<GameController> ().gameOver ();
				} else {
					enabled = false;
					Debug.Log ("Spawning new block");

					FindObjectOfType<Spawner> ().spawnRandom ();
				}
			}
			down = Time.time;
		}
	}

	bool isValidGridPosition(){
		foreach (Transform tetris in transform) {
			Vector2 pos = FindObjectOfType<Game>().Round (tetris.position);
			if (FindObjectOfType<Game>().checkIsInsideGrid (pos) == false) {
				return false;
			}
			if (FindObjectOfType<Game>().getTransformAtGridPosition(pos) != null && FindObjectOfType<Game>().getTransformAtGridPosition(pos).parent != transform) {
				return false;
			}
		}
		return true; 
	}
}