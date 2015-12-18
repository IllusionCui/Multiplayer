using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {
	public GameObject enemyPerfab;
	public int numEnemies;

	public override void OnStartServer ()
	{
		for(int i = 0; i < numEnemies; i++) {
			var pos = new Vector3 (Random.Range(-0.8f, 0.8f), enemyPerfab.transform.localPosition.y, Random.Range(-0.8f, 0.8f));

			var roatation = Quaternion.Euler (Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));

			var enemy = Instantiate (enemyPerfab, pos, roatation) as GameObject;
			NetworkServer.Spawn (enemy);
		}
	}
}
