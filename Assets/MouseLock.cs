using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {

	public TextAsset crossHairsRaw;
	private Texture2D crossHairs;

	// Use this for initialization
	void Start () {

		Cursor.lockState = CursorLockMode.Locked;

		crossHairs = new Texture2D(16,16);
		crossHairs.LoadImage(crossHairsRaw.bytes);
		Cursor.SetCursor( crossHairs, new Vector2(8,8), CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;

			Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto);
		}
	}
}
