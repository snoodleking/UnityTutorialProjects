using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	//Publics
	public int maxHits = 1;
	//Privates
	private int timesHit;
	private LevelManager levelManager;

	void Start () 
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		timesHit ++;
		SimulateWin();

		if ( timesHit >= maxHits )
		{
			Destroy( this.gameObject );
		}
	}

	//TODO remove this once you can actually win the game
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}
}
