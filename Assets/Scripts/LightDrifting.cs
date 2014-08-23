using UnityEngine;
using System.Collections;

public class LightDrifting : MonoBehaviour {

	public float driftRadius = .5f;
	public float driftTime = .6f;
	public float driftDuration = .1f;

	Vector3 driftTarget;

	Transform t;

	void Awake() {
		t = transform;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine("newDriftTarget");
	}

	IEnumerator newDriftTarget() {
		while (true) {
			driftTarget = new Vector3(Random.Range(-driftRadius,driftRadius),Random.Range(-driftRadius,driftRadius),Random.Range(-driftRadius,driftRadius));
			yield return new WaitForSeconds(driftTime + Random.Range(-.1f,.1f));
		}
	}

	// Update is called once per frame
	void Update () {
		t.localPosition = Vector3.Lerp(t.localPosition, driftTarget, driftDuration);
	}
}
