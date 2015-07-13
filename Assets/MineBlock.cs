using UnityEngine;
using System.Collections;

public class MineBlock : MonoBehaviour {

	public Material lineMaterial;

	public GameObject droppedBlockPrefab;
	public AudioClip mineSound;

	// Use this for initialization
	void Start () {
	
		// testing material and gl lines mechanism
		if( lineMaterial)
		{
			Debug.Log("Drawing Line");
			GL.PushMatrix();
			lineMaterial.SetPass(0);
			GL.Begin(GL.LINES);
			GL.Color(Color.black);
			GL.Vertex( transform.position);
			GL.Vertex( transform.position + 2*Vector3.one);
			GL.End();
			GL.PopMatrix();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		Instantiate( droppedBlockPrefab, transform.position, droppedBlockPrefab.transform.rotation);
		AudioSource.PlayClipAtPoint( mineSound, transform.position);
		Destroy( gameObject);
	}

	void OnMouseEnter()
	{
		//Debug.Log("Targeting block named " + gameObject.name + ".");
	}

	void OnMouseExit()
	{
		//Debug.Log("Done targeting block named " + gameObject.name + ".");
	}
}
