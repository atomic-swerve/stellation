using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class RemoteLightController : LightController {

	LightMovement movement;
	Light l;
	PlayerColours colour;
	ParticleSystem particles;
	
	void Awake() {
		movement = GetComponent<LightMovement>();
		l = GetComponentInChildren<Light>();
		particles = GetComponentInChildren<ParticleSystem>();
		colour = PlayerColours.White;
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
			break;
		case PlayerColours.Blue:
			newColor = new Color(.25f,.25f,.9f,.7f);
			break;
		case PlayerColours.Green:
			newColor = new Color(.25f,.9f,.25f,.7f);
			break;
		default:
			newColor = new Color(.95f,.95f,.85f,.7f);
			break;
		}

		particles.startColor = newColor;
		l.color = newColor;
	}

	void OnEnable() {
		setColourState(PlayerColours.White);
	}
}
