using UnityEngine;
using System.Collections;

public class CollectableSpawner : MonoBehaviour {

	[SerializeField]
	private PlayerController player;
	[SerializeField]
	private GameObject collectable, badCollectable;
	[SerializeField]
	private float collectableSpawnTime, badCollectableSpawnTime;
	[SerializeField]
	private bool canSpawnCollectable = true, canSpawnBadCollectable = true;
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

	private Vector3 CalculateRandomVector3 () {
		Vector3 temp = Vector3.zero;
		temp.x = Random.Range (-xClamp, xClamp);
		temp.y = Random.Range (-yClamp, yClamp);
		if (Vector3.Distance (player.transform.position, temp) < 1.5f) {
			return CalculateVector3NearBorder ();
		} else {
			return temp;
		}
	}

	private Vector3 CalculateVector3NearBorder () {
		Vector3 temp = Vector3.zero;
		if (Random.Range (0, 2) == 0) {
			temp.x = xClamp - Random.Range (0, 0.5f);
		} else {
			temp.x = -xClamp + Random.Range (0, 0.5f);
		}

		if (Random.Range (0, 2) == 0) {
			temp.x = yClamp - Random.Range (0, 0.5f);
		} else {
			temp.x = -yClamp + Random.Range (0, 0.5f);
		}

		return temp;
	}

	private void SpawnCollectable () {
		Instantiate (
			collectable,
			CalculateRandomVector3(),
			Quaternion.identity
		);
	}

	private void SpawnBadCollectable () {
		Instantiate (
			badCollectable,
			CalculateRandomVector3(),
			Quaternion.identity
		);
	}
}
