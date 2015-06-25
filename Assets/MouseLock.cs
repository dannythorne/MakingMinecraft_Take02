using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
