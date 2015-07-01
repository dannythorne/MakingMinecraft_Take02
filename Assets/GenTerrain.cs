using UnityEngine;
using System.Collections;

public class GenTerrain : MonoBehaviour {

	public GameObject block;

	// Use this for initialization
	void Start () {

		int i, j, k;
		int nk;
		
		int n = 32;
		int h = 8;
		
		for( j=-n; j<=n; j++)
		{
			for( i=-n; i<=n; i++)
			{
				nk = (int)( Mathf.Floor( h*( 1 + Mathf.Sin( 2*Mathf.PI*i/n) * Mathf.Sin( 2*Mathf.PI*j/n) )));
				for( k=0; k<nk; k++)
				{
					Instantiate( block, new Vector3( i, k, j), Quaternion.identity);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
