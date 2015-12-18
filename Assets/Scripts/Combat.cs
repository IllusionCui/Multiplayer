using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour {
	public int healthMax;
	public bool deadDestory;

	[SyncVar]
	public int currHealth;

	public void TakeDamage(int amount) {
		if (!isServer) {
			return;
		}

		currHealth -= amount;
		if (currHealth <= 0) {
			if (deadDestory) {
				Destroy (this.gameObject);
			} else {
				currHealth = healthMax;

				RpcRespawn ();
			}
		}
	}

	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer) {
			transform.position = Vector3.zero;
		}
	}
}
