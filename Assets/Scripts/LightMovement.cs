using UnityEngine;
using System.Collections;

public class LightMovement : MonoBehaviour {

	public float velocity = .1f;

	Vector2 goalPosition = Vector2.zero;
	Transform t;

	void Awake() {
		t = transform;
	}

	// Update is called once per frame
	void Update () {
		t.position = Vector3.Lerp (t.position, goalPosition, velocity);
	}

	public void setGoalPosition(Vector2 pos) {
		goalPosition = pos;
	}
}
