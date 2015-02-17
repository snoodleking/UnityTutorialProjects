using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{
	private float mousePosInBlocks;
	public Vector3 paddlePos = new Vector3();

	void Start () 
	{
		//sets the paddle to the user defined position
		this.transform.position = paddlePos;
	}
	
	void Update ()
	{	
	
		PaddleMove();	

	}

	void PaddleMove ()
	{
		//gets the input of the mouse and then sets it relative to the screen size in units
		mousePosInBlocks = ( Input.mousePosition.x / Screen.width * 16 ); 
		//print( mousePosInBlocks );
		
		//clamps the input to stay on the screen then sets the pos to match the input
		paddlePos.x = Mathf.Clamp( mousePosInBlocks, 0.5f, 15.5f );		
		this.transform.position = paddlePos;
	}
}
