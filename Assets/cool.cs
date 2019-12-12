using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cool : MonoBehaviour {
	public GameObject lol;
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Y)) {
			lol.SetActive(true);
		}
	}
}
