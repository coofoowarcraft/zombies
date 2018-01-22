using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {

	public GameObject objectToSpawn;
	public Transform spawnPoint;

	private void Update() {
		if (!isLocalPlayer) {
			return;
		}
		if (Input.GetKey (KeyCode.H)) {
			CmdSpawn();
		}
	}
	[Command]
	void CmdSpawn() {
      GameObject go = Instantiate (objectToSpawn, spawnPoint);
	  NetworkServer.Spawn (go);
	}
}
