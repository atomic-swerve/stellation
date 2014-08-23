using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LightMovement))]
public class RemoteLightController : MonoBehaviour, ILightController {
	
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
		movement.setGoalPosition((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector2.right * 10f);
	}
	
	public void setColourState() {}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		setGoalPosition();
	}
}
