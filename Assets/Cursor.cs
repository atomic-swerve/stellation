using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public float cursorPolling = .5f;

	Transform t;
	SpriteRenderer r;

	Vector3 lastpos = Vector3.zero;

	void Awake() {
		t = transform;
		r = (SpriteRenderer)renderer;
	}

	void Start() {
		Screen.showCursor = false;
		StartCoroutine("CheckMoved");
	}

	void Update () {
		t.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	IEnumerator CheckMoved() {
		while (true) {
			if (lastpos == t.position) {
				r.enabled = false;
				yield return null;
			}
			else {
				r.enabled = true;
				lastpos = t.position;
				yield return new WaitForSeconds(cursorPolling);
			}
		}
	}
}
