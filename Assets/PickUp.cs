using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		AudioSource.PlayClipAtPoint( pickupSound, transform.position);
		Destroy( gameObject);
	}
}
