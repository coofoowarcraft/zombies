using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.NetworkSystem;

public class myNetworkManager : NetworkManager {
	public Button player1Button;
	public Button player2Button;
	public Button player3Button;
	public Button player4Button;

	int characterIndex = 0;

	void Start () {
		player1Button.onClick.AddListener (delegate {CharacterPicker (player1Button.name);});
		player2Button.onClick.AddListener (delegate {CharacterPicker (player2Button.name);});
		player3Button.onClick.AddListener (delegate {CharacterPicker (player3Button.name);});
		player4Button.onClick.AddListener (delegate {CharacterPicker (player4Button.name);});
	}
	
	void CharacterPicker(string buttonName) {
		switch (buttonName) {
		case "Player1":
			characterIndex = 0;
			break;
		case "Player2":
			characterIndex = 1;
			break;
		case "Player3":
			characterIndex = 2;
			break;
		case "Player4":
			characterIndex = 3;
			break;
		}
		playerPrefab = spawnPrefabs[characterIndex];
	}
	public override void OnClientConnect(NetworkConnection conn) {
		//characterSelectionCanvas.enabled = false;
		IntegerMessage msg = new IntegerMessage(characterIndex);
		if (!clientLoadedScene) {
			ClientScene.Ready(conn);
			if (autoCreatePlayer) {
				ClientScene.AddPlayer(conn, 0, msg);
			}
		}
	}
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader) {
		int id = 0;
		if (extraMessageReader != null) {
			IntegerMessage i = extraMessageReader.ReadMessage<IntegerMessage> ();
			id = i.value;
		}
		GameObject playerPrefab = spawnPrefabs [id];
		GameObject player;
		Transform startPos = GetStartPosition ();
		if (startPos != null) {
			player = (GameObject)Instantiate (playerPrefab, startPos.position, startPos.rotation);
		} else {
			player = (GameObject)Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
		}
		NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
	}
}