using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public void LoadLevel( string levelName )
	{
		Debug.Log( "New Level Load: " + levelName );
		Application.LoadLevel( levelName );
	}
	
	public void QuitRequest ()
	{
		Debug.Log( "Quit Pressed" );
		Application.Quit();
	}


}
