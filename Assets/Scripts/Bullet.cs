using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int damageValue;

	void OnCollisionEnter(Collision collision) {
		var hit = collision.gameObject;
		var combat = hit.GetComponent<Combat> ();
		if (combat != null) {
			combat.TakeDamage (damageValue);

			Destroy (gameObject);
		}
	}
}
