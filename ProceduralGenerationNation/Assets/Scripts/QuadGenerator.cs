using UnityEngine;
using System.Collections;

[RequireComponent( typeof( MeshFilter ) )]
[ExecuteInEditMode]

public class QuadGenerator : MonoBehaviour 
{


	void Start ()
	{
		//Define vertices for mesh
		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = MakeQuad
			(
				new Vector3( 0, 1, 0 ),
				new Vector3( 1, 0, 0 )
			);
	}

	public static Mesh MakeQuad( Vector3 A, Vector3 B )
	{
		Vector3[] vertices = new Vector3[4];
		vertices [0] = new Vector3 (0, 0, 0);
		vertices [1] = A;
		vertices [2] = A+B;
		vertices [3] = B;
		//Define triangles that the vertices create
		int[] triangles = new int[6];
		triangles [0] = 0;
		triangles [1] = 1;
		triangles [2] = 2;
		triangles [3] = 0;
		triangles [4] = 2;
		triangles [5] = 3;
		//Define UV coordinates
		Vector2[] uvs =  {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2 (1, 1),
			new Vector2 (1, 0)
		};
		//Mesh Components
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		mesh.normals = CalculateNormals (mesh);
		mesh.RecalculateBounds ();
		return mesh;
	}
	
	public static Vector3[] CalculateNormals ( Mesh mesh )
	{	
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles; 
		
		Vector3[] normals = new Vector3[4];
		//Zeroes out normals
		for (int ni = 0; ni < vertices.Length; ni++) 
		{
			normals [ni] = new Vector3 (0, 0, 0);
		}
		
		for (int i = 0; i < triangles.Length; i += 3)
		{
			int indexOfA = triangles [i];
			Vector3 A = vertices [indexOfA];
			Vector3 B = vertices [triangles [i + 1]];
			Vector3 C = vertices [triangles [i + 2]];
			Vector3 normal = Vector3.Cross (B - A, C - A);
			normals [indexOfA] = normals [indexOfA] + normal;
			normals [triangles [i + 1]] = normals [triangles [i + 1]] + normal;
			normals [triangles [i + 2]] = normals [triangles [i + 2]] + normal;
		}
		
		for (int ni = 0; ni < vertices.Length; ni++)
		{
			normals [ni] = normals [ni].normalized;
		}
		
		return normals;
	}
}
