using UnityEngine;
using System.Collections;

public class WireFrame : MonoBehaviour {

	public Material wireMaterial;
	public GameObject targetBlock;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPostRender()
	{
		if( targetBlock && targetBlock.GetComponent<MineBlock>().drawWireFrame)
		{
			GL.PushMatrix();
			wireMaterial.SetPass(0);
			GL.Begin(GL.LINES);
			
			// Left to right lines
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.down);

			// Up and down lines
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.down);

			// Front to back lines
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.forward + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.left + 0.51f*Vector3.back + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.up);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.forward + 0.51f*Vector3.down);
			GL.Vertex( targetBlock.transform.position + 0.51f*Vector3.right + 0.51f*Vector3.back + 0.51f*Vector3.down);

			GL.End();
			GL.PopMatrix();
		}
	}
	
}
