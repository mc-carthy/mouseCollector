using UnityEngine;
using System.Collections;

public class CollectableSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject collectable, badCollectable;
	[SerializeField]
	private float collectableSpawnTime, badCollectableSpawnTime;
	[SerializeField]
	private bool canSpawnCollectable, canSpawnBadCollectable;
	private float xClamp, yClamp;

	private void Start () {
		xClamp = Camera.main.orthographicSize * Screen.width / Screen.height - 1;
		yClamp = Camera.main.orthographicSize - 1;
		StartCoroutine (SpawnCollectables ());
		StartCoroutine (SpawnBadCollectables ());
	}

	private IEnumerator SpawnCollectables () {
		while (canSpawnCollectable) {
			yield return new WaitForSeconds (collectableSpawnTime);
			SpawnCollectable ();
		}
	}

	private IEnumerator SpawnBadCollectables () {
		while (canSpawnBadCollectable) {
			yield return new WaitForSeconds (badCollectableSpawnTime);
			SpawnBadCollectable ();
		}
	}

	private void SpawnCollectable () {
		Instantiate (
			collectable,
			new Vector3(Random.Range(-xClamp, xClamp), Random.Range(-yClamp, yClamp), 0),
			Quaternion.identity
		);
	}

	private void SpawnBadCollectable () {
		Instantiate (
			badCollectable,
			new Vector3(Random.Range(-xClamp, xClamp), Random.Range(-yClamp, yClamp), 0),
			Quaternion.identity
		);
	}
}
