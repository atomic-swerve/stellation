using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class PlayerLightController : LightController {

	public bool useMockClient = true;

	IClient client;

	void Awake() {
		movement = GetComponent<LightMovement>();
		l = GetComponentInChildren<Light>();
		line = GetComponentInChildren<LineRenderer>();
		t = transform;
		g = gameObject;

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
			g.layer = 9;
			break;
		case PlayerColours.Blue:
			newColor = new Color(.25f,.25f,.9f);
			g.layer = 10;
			break;
		case PlayerColours.Green:
			newColor = new Color(.25f,.9f,.25f);
			g.layer = 11;
			break;
		default:
			newColor = new Color(.95f,.95f,.85f);
			g.layer = 8;
			break;
		}
		
		particles.startColor = newColor;
		l.color = newColor;
		line.SetColors(newColor,newColor);
	}

	// Use this for initialization
	void Start () {
		StartCoroutine("ColourUpdate");
		setColourState(PlayerColours.White);
	}

	IEnumerator ColourUpdate() {
		while (true) {
			client.sendUpdateColour(colour);
			yield return new WaitForSeconds(2f);
		}
	}

	// Update is called once per frame
	void Update () {
		if (setGoalPosition()) {
			client.sendUpdateState(t);
		}
		GetLineToNearestLight();
	}

	void OnDisable() {
		client.disconnectFromServer();
	}
}
