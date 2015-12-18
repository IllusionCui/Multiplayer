using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {
	public GameObject bulletPerfab;
	public float moveRate = 0.1f;

	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer> ().material.color = Color.red;
	}

	[Command]
	void CmdFire() {
		var bullet = Instantiate (bulletPerfab, transform.position - transform.forward, Quaternion.identity) as GameObject;

		bullet.GetComponent<Rigidbody> ().velocity = -transform.forward * 4;

		NetworkServer.Spawn (bullet);

		Destroy (bullet, 2.0f);
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}

		var x = Input.GetAxis ("Horizontal")*moveRate;
		var z = Input.GetAxis ("Vertical")*moveRate;

		transform.Translate (x, 0, z);

		if (Input.GetKeyDown(KeyCode.Space)) {
			CmdFire ();
		}
	}
}
