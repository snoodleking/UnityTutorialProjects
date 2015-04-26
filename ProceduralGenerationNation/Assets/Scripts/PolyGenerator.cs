using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent( typeof( MeshFilter ) )]

public class PolyGenerator : MonoBehaviour 
{

	void Start () 
	{
		Vector3[] vertices = new Vector3[5];

		vertices[0] = new Vector3( 0, 0, 0 );
		vertices[1] = new Vector3( 0, 1, 0 );
		vertices[2] = new Vector3( .5f, 1.5f, 0 );
		vertices[3] = new Vector3( 1, 1, 0 );
		vertices[4] = new Vector3( 1, 0, 0 );

		int[] triangles = new int[9];

		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 4;
		triangles[6] = 2;
		triangles[7] = 3;
		triangles[8] = 4;

		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();

		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = mesh;
	}
}
