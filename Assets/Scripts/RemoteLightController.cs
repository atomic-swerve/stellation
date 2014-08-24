using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class RemoteLightController : MonoBehaviour {

	LightMovement movement;
	Light l;
	
	void Awake() {
		movement = GetComponent<LightMovement>();
		l = GetComponentInChildren<Light>();
	}
	
	public void setGoalPosition(float x, float y) {
		movement.setGoalPosition(new Vector2(x,y));
	}
	
	public void setColourState() {}
}
