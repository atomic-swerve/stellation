using UnityEngine;
using System.Collections;

public class LightMovement : MonoBehaviour {

	public float velocity = .1f;

	Transform t;

	void Awake() {
		t = transform;
	}

	// Update is called once per frame
	void Update () {
		t.position = Vector3.Lerp (t.position, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), velocity);
	}
}
