using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{

	private Paddle paddle;
	private bool hasStarted = false; 
	
	private Vector3 paddleToBallVector;

	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update ()
	{	
		if ( !hasStarted )
		{	
			//locks the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//wait for mouse press to launch
			if ( Input.GetMouseButtonDown( 0 ) )
			{	
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2( 2f, 10f ); 
			}
		}
	}
}
