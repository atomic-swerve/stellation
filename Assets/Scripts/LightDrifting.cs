using UnityEngine;
using System.Collections;

public class LightDrifting : MonoBehaviour {

	public float driftRadius = .5f;
	public float driftTime = .6f;
	public float driftDuration = 1f;

	float lastUpdate = 0;
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
			lastUpdate = 0;
			yield return new WaitForSeconds(driftTime);
		}
	}

	// Update is called once per frame
	void Update () {
		lastUpdate += Time.deltaTime/driftDuration;
		t.localPosition = Vector3.Lerp(t.localPosition, driftTarget, Mathf.SmoothStep(0,1f,lastUpdate));
	}
}
