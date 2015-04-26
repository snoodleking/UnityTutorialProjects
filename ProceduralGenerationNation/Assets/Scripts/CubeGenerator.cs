using UnityEngine;
using System.Collections;

[RequireComponent( typeof( MeshFilter ) )]
[ExecuteInEditMode]

public class CubeGenerator : MonoBehaviour {
	
	void Start () 
	{
		Mesh cube = new Mesh();

		//Front
		cube = MeshBuilder.Combine
			(cube,  QuadGenerator.MakeQuad
				(
					new Vector3( 0, 1, 0 ),
					new Vector3( 1, 0, 0 )
				));   
		//Left
		cube = MeshBuilder.Combine
			(cube,  QuadGenerator.MakeQuad
			 (
				new Vector3( 0, 0, 1 ),
				new Vector3( 0, 1, 0 )
				));  

		//Right
		cube = MeshBuilder.Combine
			(cube,  MeshBuilder.Offset( QuadGenerator.MakeQuad
			 (
				new Vector3( 0, 1, 0 ),
				new Vector3( 0, 0, 1 )
				), new Vector3( 1, 0, 0 )));  

		//Bottom
		cube = MeshBuilder.Combine
			(cube,  QuadGenerator.MakeQuad
			 (
				new Vector3( 1, 0, 0 ),
				new Vector3( 0, 0, 1 )
				)); 

		//Rear
		cube = MeshBuilder.Combine
			(cube,  MeshBuilder.Offset( QuadGenerator.MakeQuad
			 (
				new Vector3( 0, -1, 0 ),
				new Vector3( 1, 0, 0 )
				), new Vector3(0, 1, 1 )));  

		//Top
		cube = MeshBuilder.Combine
			(cube,  MeshBuilder.Offset( QuadGenerator.MakeQuad
			                           (
				new Vector3( 0, 0, 1 ),
				new Vector3( 1, 0, 0 )
				), new Vector3(0, 1, 0 )));

		cube = MeshBuilder.Offset( cube, new Vector3( -.5f, -.5f, -.5f ));

		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = cube;
	}
}
