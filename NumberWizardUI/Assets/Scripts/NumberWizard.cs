using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

//Variables
public Text guessText, guessCountText;
private int guess, guessCount, min, max;


	void Start () 
	{
		//setting start values
		min = 0;
		max = 1000;
		guessCount = 1;
		guess = Random.Range ( min, max );
		
		//setting UI
		guessCountText.text = (guessCount.ToString() );
		guessText.text = ( guess.ToString() );
	}
	
	void Update () 
	{
	
	}

	public void IsGreater()
	{
		//setting the minimum to what was just guessed.
		Debug.Log ( "Is Greater has been pressed ");
		min = guess;
		NextGuess ();
	}
	
	public void IsLessThan()
	{
		//setting the maximum to what was just guessed.
		Debug.Log ( "Is Less Than has been pressed ");
		max = guess;
		NextGuess ();
	}

	void NextGuess ()
	{
		//based on the input of the player, a new guess is made.
		//and the guess counter goes up by one.
		guessCount += 1;
		guess = Random.Range ( min, max );

		//setting the UI
		guessCountText.text = ( guessCount.ToString() );
		guessText.text = ( guess.ToString() ); 
	}

}
