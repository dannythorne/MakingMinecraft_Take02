using UnityEngine;
using System.Collections;

public class MineBlock : MonoBehaviour {

	public GameObject droppedBlockPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		Instantiate( droppedBlockPrefab, transform.position, droppedBlockPrefab.transform.rotation);
		Destroy( gameObject);
	}
}
