using UnityEngine;
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

	private void MovePlayerToMouse () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = transform.position.z - Camera.main.transform.position.z;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.position = Vector3.MoveTowards (transform.position, mousePos, moveSpeed * Time.deltaTime);
	}

	private void HideMouseCursor () {
		Cursor.visible = false;
	}
}
