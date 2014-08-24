using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class PlayerLightController : MonoBehaviour {

	public bool useMockClient = true;

	IClient client;
	LightMovement movement;
	Light l;
	Transform t;

	void Awake() {
		movement = GetComponent<LightMovement>();
		l = GetComponentInChildren<Light>();
		t = transform;

		if (useMockClient) {
			client = FindObjectOfType<MockClient>();
		}
		else {
			client = FindObjectOfType<RemoteClient>();
		}
	}

	public void setGoalPosition() {
		movement.setGoalPosition((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public void setColourState() {}

	// Use this for initialization
	void Start () {
		StartCoroutine("UpdateServer");
	}
	
	// Update is called once per frame
	void Update () {
		setGoalPosition();
	}

	IEnumerator UpdateServer() {
		while (true) {
			client.sendUpdateState(t);
			yield return new WaitForSeconds(.1f);
		}
	}

	void OnDisable() {
		client.disconnectFromServer();
	}
}
