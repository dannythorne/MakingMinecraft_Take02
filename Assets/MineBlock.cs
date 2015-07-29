using UnityEngine;
using System.Collections;

public class MineBlock : MonoBehaviour {

	public bool drawWireFrame;
	public GameObject fpsController;

	public GameObject droppedBlockPrefab;
	public AudioClip mineSound;

	// Use this for initialization
	void Start () {

		drawWireFrame = false;

		fpsController = GameObject.Find("FirstPersonCharacter");
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
		drawWireFrame = true;

		fpsController.GetComponent<WireFrame>().targetBlock = gameObject;
	}
	
	void OnMouseExit()
	{
		drawWireFrame = false;
	}
	
}
