using UnityEngine;
using System.Collections;

[RequireComponent( typeof( MeshFilter ) )]
[ExecuteInEditMode]

public class QuadGenerator : MonoBehaviour 
{

	void Start ()
	{
		Vector3[] vertices = new Vector3[4];

		vertices[0] = new Vector3( 0, 0, 0 );
		vertices[1] = new Vector3( 0, 1, 0 );
		vertices[2] = new Vector3( 1, 1, 0 );
		vertices[3] = new Vector3( 1, 0, 0 );

		int[] triangles = new int[6];

		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;

		Vector2[] uvs = 
		{
			new Vector2( 0, 0 ),
			new Vector2( 0, 1 ),
			new Vector2( 1, 1 ),
			new Vector2( 1, 0 )
		};

		Vector3[] normals = new Vector3[4];

		for ( int ni = 0; ni < vertices.Length; ni++ )
		{
			normals[ni] = new Vector3( 0, 0, 0 );
		}

		for ( int i = 0; i < triangles.Length; i += 3 )
		{
			int indexOfA = triangles[i];
			Vector3 A = vertices[indexOfA];
			Vector3 B = vertices[triangles[i + 1]];
			Vector3 C = vertices[triangles[i + 2]];
			Vector3 normal = Vector3.Cross( B-A, C-A );
			normals[indexOfA] = normals[indexOfA] + normal;
			normals[triangles[i + 1]] = normals[triangles[i + 1]] + normal;
			normals[triangles[i + 2]] = normals[triangles[i + 2]] + normal;
		}

		for ( int ni = 0; ni < vertices.Length; ni++ )
		{
			normals[ni] = normals[ni].normalized;
		}



		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.uv = uvs;
		mesh.normals = normals;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();

		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = mesh;
	}
}
