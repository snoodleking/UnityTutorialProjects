﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour 
{

	static MusicPlayer instance = null;

	void Awake ()
	{
		if ( instance != null )
		{
			Destroy ( gameObject );
			print ( "destroying duplicate music player" );
		}
		else
		{	
			instance = this;
			GameObject.DontDestroyOnLoad( gameObject );
		}
	}
	
	void Start ()
	{

	}
	

	void Update () 
	{
	
	}
}
