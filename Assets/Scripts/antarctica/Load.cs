using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Load : MonoBehaviour {

	private void Start() {
		Switch();
	}

	public void Switch() {
		SteamVR_LoadLevel.Begin("innerearth");
	}
}
