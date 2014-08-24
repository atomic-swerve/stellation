using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class RemoteLightController : LightController {

	void Awake() {
		movement = GetComponent<LightMovement>();
		l = GetComponentInChildren<Light>();
		t = transform;
		g = gameObject;
		particles = GetComponentInChildren<ParticleSystem>();
		line = GetComponentInChildren<LineRenderer>();
		colour = PlayerColours.White;
		nearbyLights = new Collider2D[100];
	}
	
	public void setGoalPosition(float x, float y) {
		movement.setGoalPosition(new Vector2(x,y));
	}
	
	public override void setColourState(PlayerColours c) {
		colour = c;
		Color newColor;

		switch (c) {
		case PlayerColours.Red:
			newColor = new Color(.9f,.25f,.25f,.7f);
			g.layer = 9;
			break;
		case PlayerColours.Blue:
			newColor = new Color(.25f,.25f,.9f,.7f);
			g.layer = 10;
			break;
		case PlayerColours.Green:
			newColor = new Color(.25f,.9f,.25f,.7f);
			g.layer = 11;
			break;
		default:
			newColor = new Color(.95f,.95f,.85f,.7f);
			g.layer = 8;
			break;
		}

		particles.startColor = newColor;
		l.color = newColor;
		line.SetColors(newColor, connected == null ? newColor : connected.l.color);
	}

	void Update() {
		GetLineToNearestLight();
	}

	void OnEnable() {
		setColourState(PlayerColours.White);
	}
}
