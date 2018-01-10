using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text scoreValue;
	[SerializeField]
	Text gameoverLabel;
	[SerializeField]
	Text highscoreLabel;
	[SerializeField]
	Button playagainBtn;

	private int _score  = 0;
	private int _highScore = 0;

	public int Score {
		get{ return _score; }
		set {
			_score = value; 
			updateUI ();
		}
	}

	public int Highscore {
		get{ return _score; }
		set {
			_score = value; 
			updateUI ();
		}
	}

	// Use this for initialization
	void Start () {
		initialize ();
	}

	// Update is called once per frame
	void Update () {
		updateUI ();
	}

	//sets start of the game UI
	private void initialize(){
		Time.timeScale = 1;
		Score = 0;
		scoreLabel.gameObject.SetActive (true);
		scoreValue.gameObject.SetActive (true);
		gameoverLabel.gameObject.SetActive (false);
		highscoreLabel.gameObject.SetActive (false);
		playagainBtn.gameObject.SetActive (false);
	}

	//shows game over, high score and play again button
	//hides life and score label
	public void gameOver(){
		Time.timeScale = 0;
		Highscore = Score;
		scoreLabel.gameObject.SetActive (false);
		scoreValue.gameObject.SetActive (false);
		gameoverLabel.gameObject.SetActive (true);
		highscoreLabel.gameObject.SetActive (true);
		playagainBtn.gameObject.SetActive (true);
	}

	//updates UI 
	public void updateUI(){
		scoreValue.text = _score.ToString();
		highscoreLabel.text = "Your Score: " + _score;
	}

	// This method is called when play again button is clicked
	// Restarts the game
	public void playagainBtnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void increaseRowScore(){
		_score += 100;
	}
}