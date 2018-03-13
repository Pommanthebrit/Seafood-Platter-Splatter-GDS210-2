using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows access to UI elemenmts

//script written by Aston Olsen

public class ScoreBoardController : MonoBehaviour {

	public Text[] highScores; //Array for high score text fields
	int[] highScoreValues; //Array for high score values
	int finalScore; //Value for player score after game over
	string[] highScoreNames; //Array for high score player Names
	public GameObject nameInputBox, submitButton, quitToMenuButton; //UI objects that can be enabled or disabled as required
	public InputField playerName; //Player name input on scoreboard
	AudioSource myAudioSource;
	public AudioClip wowNewHighScore; //assigns sound clip

	void Start () {
		highScoreValues = new int[highScores.Length]; //Sets the number of array entries in highScoreValues to the same amount as the array length of highScores
		highScoreNames = new string[highScores.Length]; //Sets the number of array entries in highScoreNames to the same amount as the array length of highScores
			for (int x = 0; x < highScores.Length; x++) { //runs this loop for each score in the highScores array
				//if(PlayerPrefs.HasKey("highScoreValues" + x)) // checks if highscore key exists
					highScoreValues[x] = PlayerPrefs.GetInt ("highScoreValues" + x); //each time the loop runs, gets one of the highScoreValues from PlayerPrefs
				//else
				//	PlayerPrefs.SetInt("highScoreValues" + x, 0); // if no highscore exists create one
				if(PlayerPrefs.HasKey("highScoreNames" + x)) // checks if highscore key exists
					highScoreNames[x] = PlayerPrefs.GetString ("highScoreNames" + x); //each time the loop runs, gets one of the highScoreNames from PlayerPrefs
				else
					PlayerPrefs.SetString("highScoreNames" + x, "N/A"); // if no highscore exists create one
			}
		DrawScores ();
	}

	void SaveScores(){ //function for saving scores
		for (int x = 0; x < highScores.Length; x++) { //runs this loop for each score in the highScores array
			PlayerPrefs.SetInt ("highScoreValues" + x, highScoreValues [x]); //each time the loop runs, sets one of the highScoreValues from PlayerPrefs
			PlayerPrefs.SetString ("highScoreNames" + x, highScoreNames [x]); //each time the loop runs, sets one of the highScoreNames from PlayerPrefs
		}
	}

	public void CheckForHighScore(int _value, string _userName){ //function for checking high scores
		for (int x = 0; x < highScores.Length; x++) { //runs this loop for each score in the highScores array
			if (_value > highScoreValues [x]) { //checks if the users score value is greater than the array value currently being checked from highScoreValues. If it is, do the for loop below
				for (int y = highScores.Length -1; y > x; y--){ //checks if the new score value is greater than the next score down on the list. If it is, do the loop steps below
					highScoreValues [y] = highScoreValues [y - 1]; //moves the scoreValue down a spot on the scoreboard
					highScoreNames [y] = highScoreNames [y - 1]; //moves the scoreName down a spot on the scoreboard
				}
			highScoreValues [x] = _value; //sets the highScoreValues to the current score value for each iteration of the loop
			highScoreNames [x] = _userName; //sets the highScoreNames to the current score value for each iteration of the loop
			DrawScores ();
			SaveScores ();
			break;
			}
		}
	}

	void DrawScores() { //function for displaying scores on scoreboard
		for (int x = 0; x < highScores.Length; x++) { //runs this loop for each score in the highScores array
			highScores [x].text = "#" + (x+1).ToString() + " " + highScoreNames [x] + ":" + highScoreValues [x].ToString (); //Updates the highscore text boxes on the scoreboard
		} 
	}

	public void SubmitScore(){ //function for entering name on scoreboard. This function will be called by clicking the "Submit" button on the scoreboard (after the player has entered their name)
		//CheckForHighScore (myScore, playerName.text); //calls function and passes variables
		nameInputBox.SetActive (false); //Disables name input box
		submitButton.SetActive (false); //Disables submit button

		finalScore = PlayerPrefs.GetInt ("highScoreValues" + 9); //Gets #10 high score
//		if (myScore > finalScore) { //checks if current score > #10 high score
//			NewHighScore();	//calls function with time delay
//		}
	}

	public void NewHighScore() { //function for when player gets a new high score
		//Could add sounds UI pop-ups here
		myAudioSource = GetComponent<AudioSource> (); //Gets audio source
		myAudioSource.PlayOneShot (wowNewHighScore); //Plays audio file
	}

}
