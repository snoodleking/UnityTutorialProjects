using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour 
{

	public LevelManager levelManager;
	
	//detects if the collider is not a trigger
	void OnCollisionEnter2D ( Collision2D collision )
	{
		print ( "Collision detected." );
		levelManager.LoadLevel( "WinScreen" );	
	}
	
	//detects if the collider is considered a trigger
	void OnTriggerEnter2D ( Collider2D trigger )
	{
		print ( "Trigger detected." );
		levelManager.LoadLevel( "WinScreen");
	}

}
