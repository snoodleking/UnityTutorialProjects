using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {


	// Variables================
	public Text text;
	public string desiredText;

	private enum State {cell, mirror_0, sheets_0, sheets_1, lock_0, lock_1};
	private State myState;
	//==========================

	void Update () 
	{
		print ( myState );

		switch ( myState )
		{
			case State.cell:
				StateCell();
				break;

			case State.mirror_0:
				StateMirror0();
				break;

			default:
				break;
		}
	}

	void StateCell()
	{
		desiredText = 	"You're in a shitty cell. \n\n" +
						"Press M to look at the Mirror, " +
						"Press L to look at the Lock, " +
						"Press S to look at the Sheets.";
		UpdateText();
		
		if ( Input.GetKeyDown( KeyCode.M ) )
		{
			myState = State.mirror_0;
		}
	}

	void StateMirror0()
	{
		desiredText = 	"You look pretty today. " +
						"R to Return to your shitty cell.";
		
		UpdateText ();

		if ( Input.GetKeyDown( KeyCode.R ) )
			{
				myState = State.cell;
			}
	}

	void UpdateText()
	{
		text.text = ( desiredText );
	}
}
