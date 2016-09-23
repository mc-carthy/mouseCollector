using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 1f;

	private void Start () {
		HideMouseCursor ();
	}

	private void Update () {
		MovePlayerToMouse ();
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.tag == "collectable") {
			Destroy (trig.gameObject);
		}

		if (trig.tag == "badCollectable") {
			RestartLevel ();
		}
	}

	private void MovePlayerToMouse () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = transform.position.z - Camera.main.transform.position.z;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.position = Vector3.MoveTowards (transform.position, mousePos, moveSpeed * Time.deltaTime);
	}

	private void HideMouseCursor () {
		Cursor.visible = false;
	}

	private void RestartLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
	}
}
