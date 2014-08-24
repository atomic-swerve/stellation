using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class PlayerLightController : LightController {

	public bool useMockClient = true;

	IClient client;
	LightMovement movement;
	Light l;
	Transform t;
	PlayerColours colour;
	ParticleSystem particles;

	void Awake() {
		movement = GetComponent<LightMovement>();
		l = GetComponentInChildren<Light>();
		t = transform;

		colour = PlayerColours.White;
		
		particles = GetComponentInChildren<ParticleSystem>();

		if (useMockClient) {
			client = FindObjectOfType<MockClient>();
		}
		else {
			client = FindObjectOfType<RemoteClient>();
		}
	}

	public bool setGoalPosition() {
		return movement.setGoalPosition((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public override void setColourState(PlayerColours c) {
		colour = c;
		Color newColor;
		
		switch (c) {
		case PlayerColours.Red:
			newColor = new Color(.9f,.25f,.25f);
			break;
		case PlayerColours.Blue:
			newColor = new Color(.25f,.25f,.9f);
			break;
		case PlayerColours.Green:
			newColor = new Color(.25f,.9f,.25f);
			break;
		default:
			newColor = new Color(.95f,.95f,.85f);
			break;
		}
		
		particles.startColor = newColor;
		l.color = newColor;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine("ColourUpdate");
		setColourState(PlayerColours.White);
	}

	IEnumerator ColourUpdate() {
		while (true) {
			client.sendUpdateColour(colour);
			yield return new WaitForSeconds(1f);
		}
	}

	// Update is called once per frame
	void Update () {
		if (setGoalPosition()) {
			client.sendUpdateState(t);
		}
	}

	void OnDisable() {
		client.disconnectFromServer();
	}
}
