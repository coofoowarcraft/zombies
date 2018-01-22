using UnityEngine;
using UnityEngine.Networking;
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : NetworkBehaviour {
	public float playerSpeed = 4f;
	void Update() {
	  if (!isLocalPlayer) {
	    return;
	  }
		Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		GetComponent<Rigidbody2D>().velocity=targetVelocity * playerSpeed;
	}
}





/*
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}
}
*/