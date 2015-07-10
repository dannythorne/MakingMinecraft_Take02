using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUp : MonoBehaviour {

	private static int numCollected = 0;

	private Text numCollectedText;

	public AudioClip pickupSound;

	// Use this for initialization
	void Start () {

		numCollectedText = GameObject.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround( transform.position, Vector3.up, 100*Time.deltaTime);
	
	}

	void OnTriggerEnter()
	{
		numCollected++;
		numCollectedText.text = numCollected.ToString();

		AudioSource.PlayClipAtPoint( pickupSound, transform.position);
		Destroy( gameObject);
	}
}
