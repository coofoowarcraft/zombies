using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterselector : MonoBehaviour {

	public GameObject player;
	public Vector3 playerSpawnPosition = new Vector3 (0,1,-7);
	public Character[] characters;

	public void OnCharacterSelect(int characterChoice) {
		GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;
		Character selectedCharacter = characters[characterChoice];
	}
}