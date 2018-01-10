using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int _score  = 0;
	private int _life = 0;
	public GameController gameCtrl;
	static private Player _instance;

	private Player(){

	}

	public int Score {
		get{ return _score; }
		set {
			_score = value; 
			gameCtrl.updateUI ();
		}
	}


	public int Highscore {
		get{ return _score; }
		set {
			_score = value; 
			gameCtrl.updateUI ();
		}
	}
	public int Life {
		get{ return _life; }
		set { 
			_life = value; //update UI

			if (_life <= 0) {
				gameCtrl.gameOver ();
			} else {
				gameCtrl.updateUI ();
			}
		}
	}
}
