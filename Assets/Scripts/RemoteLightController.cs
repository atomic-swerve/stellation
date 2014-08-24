using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class RemoteLightController : MonoBehaviour {

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
	
	public void setColourState(PlayerColours c) {
		colour = c;
		Color newColor;

		switch (c) {
		case PlayerColours.Red:
			newColor = new Color(232,50f,50f,150f);
			break;
		case PlayerColours.Blue:
			newColor = new Color(50f,50f,232f,150f);
			break;
		case PlayerColours.Green:
			newColor = new Color(50f,232f,50f,150f);
			break;
		default:
			newColor = new Color(244f,244f,212f,150f);
			break;
		}

		particles.startColor = newColor;
		l.color = newColor;
	}

	void OnEnable() {
		setColourState(PlayerColours.White);
	}
}
