using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static int gridWidth = 10;
	public static int gridHeight = 16;
	public static Transform[,] grid = new Transform[gridWidth, gridHeight];
	public int scoreLine = 100;
	private int noOfRows = 0;

	void Update(){
		updateScore ();
	}

	public void updateScore(){
		//if rows cleared, update score
		if (noOfRows > 0) {
			FindObjectOfType<GameController>().increaseRowScore ();
			noOfRows = 0;
		}
	}
		
	public bool isFullRowAt(int y){
		for (int x = 0; x < gridWidth; ++x) {
			if (grid [x, y] == null) {
				return false;
			}
		}
		noOfRows++;
		return true;
	}
		
	public void deleteBlockAt(int y){
		for (int x = 0; x < gridWidth; ++x) {
			Destroy (grid [x, y].gameObject);
			grid [x, y] = null;
		}
	}

	public void moveRowDown(int y){
		for (int x = 0; x < gridWidth; ++x) {
			if (grid [x, y] != null) {
				grid [x, y - 1] = grid [x, y];
				grid [x, y] = null;
				grid [x, y - 1].position += new Vector3 (0, -1, 0);
			}
		}
	}

	public void moveAllRowsDown(int y){
		for (int i = y; i < gridHeight; ++i) {
			moveRowDown (i);
		}
	}

	public void deleteRow(){
		for (int y = 0; y < gridHeight; ++y) {
			if(isFullRowAt(y)){
				deleteBlockAt(y);
				moveAllRowsDown(y+1);
				--y;
			}
		}
	}

	public void updateGrid(TetrisController t){
		//remove old tetris from game
		for(int y = 0; y < gridHeight; ++y){
			for(int x = 0; x < gridWidth; ++x){
				if(grid[x, y] != null){
					if(grid[x, y].parent == t.transform){
						grid[x, y] = null;
					}
				}
			}
		}
		foreach (Transform tetris in t.transform) {
			Vector2 position = Round (tetris.position);
			if (position.y < gridHeight && position.x < gridWidth) {
				grid [(int)position.x, (int)position.y] = tetris;
			}
		}
	}

	public Vector2 Round(Vector2 pos){
		return new Vector2 (Mathf.Round (pos.x), 
			Mathf.Round (pos.y));
	}

	public bool checkIsInsideGrid(Vector2 pos){
		return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y > 0);
	}

	public Transform getTransformAtGridPosition(Vector2 pos){
 		if(pos.y > gridHeight - 1){
			return null;
		}
		else{
			if ((int)pos.x < gridWidth && (int)pos.y < gridHeight) {
				//Debug.Log ("get Transform at GRID position : " + (int)pos.x + "" + (int)pos.y);
				return grid [(int)pos.x, (int)pos.y];
			} else
				return null;
		}
	}

	public bool checkIsAtTop(TetrisController t){
		Debug.Log ("TOP Position : " + t.transform.position.y);
		for (int i = 0; i < gridWidth; ++i) {
			foreach (Transform tetris in t.transform) {
				Vector2 pos = Round (tetris.position);
				if (pos.y > gridHeight - 1) {
					return true;
				}
			}
		}
		return false;
	}

	public bool checkCanMoveRight(Vector2 pos){
		return ((int)pos.x < gridWidth && (int)pos.y > 0);
	}

	public bool checkCanMoveLeft(Vector2 pos){
		return ((int)pos.x >= 0 && (int)pos.y > 0);
	}

	public bool checkCanMoveDown(Vector2 pos){
		return (int)pos.y > 0;
	}
}