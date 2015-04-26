using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour 
{

	private LevelManager levelManager;

	void Start()
	{
		//Links the level manager up programmatically
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	//detects if the collider is not a trigger
	void OnCollisionEnter2D ( Collision2D collision )
	{
		levelManager.LoadLevel( "LoseScreen" );	
	}
	
	//detects if the collider is considered a trigger
	void OnTriggerEnter2D ( Collider2D trigger )
	{
		levelManager.LoadLevel( "LoseScreen");
	}

}
