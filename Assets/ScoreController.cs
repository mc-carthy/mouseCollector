using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static ScoreController instance;

	[SerializeField]
	private Text scoreText;
	private int score;

	private void Start () {
		MakeInstance ();
		UpdateScore ();
	}

	public void IncrementScore (int value = 1) {
		score += value;
		UpdateScore ();
	}

	private void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}
}