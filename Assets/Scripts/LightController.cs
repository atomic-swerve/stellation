using UnityEngine;
using System.Collections;

public abstract class LightController : MonoBehaviour {
	public LightController connected;
	protected LightMovement movement;
	protected Light l;
	protected LineRenderer line;
	public Transform t;
	protected PlayerColours colour;
	protected ParticleSystem particles;
	protected GameObject g;

	protected Collider2D[] nearbyLights;

	public abstract void setColourState(PlayerColours c);

	protected void GetLineToNearestLight() {
		int i;
		for (i = 0; i < Physics2D.OverlapCircleNonAlloc((Vector2)t.position, 20f, nearbyLights, g.layer); i++) {
			if (connected == null || Vector2.Distance(t.position,nearbyLights[i].transform.position) < Vector2.Distance(t.position, connected.t.position))
			{
				connected = nearbyLights[i].GetComponent<LightController>();
			}
		}
		if (i == 0) connected = null;

		if (connected == null) {
			line.enabled = false;
		}
		else
		{
			line.SetPosition(0, t.position);
			line.SetPosition(1, connected.t.position);
		}
	}
}
