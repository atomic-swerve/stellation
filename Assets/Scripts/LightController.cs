using UnityEngine;
using System.Collections;

public abstract class LightController : MonoBehaviour {
	public LightController connected;
	protected LightMovement movement;
	public Light l;
	protected LineRenderer line;
	public Transform t;
	public PlayerColours colour;
	protected ParticleSystem particles;
	protected GameObject g;

	protected Collider2D[] nearbyLights;

	public abstract void setColourState(PlayerColours c);

	protected void GetLineToNearestLight() {
		if (connected == null || connected.enabled == false || Vector2.Distance(connected.t.position,t.position) >= 60f) {
			connected = null;
		}

		if (connected == null) {
			int hit = Physics2D.OverlapCircleNonAlloc((Vector2)t.position, 10f, nearbyLights, 1<<g.layer);
			if (hit == 0) connected = null;
			else {
				for (int i = 0; i < hit; i++) {
					if (nearbyLights[i] != this.collider2D && (connected == null || Vector2.Distance(t.position,nearbyLights[i].transform.position) < Vector2.Distance(t.position, connected.t.position)))
					{
						LightController k = nearbyLights[i].GetComponent<LightController>();
						if (k.connected != this) {
							connected = k;
						}
					}
				}
			}
		}

		if (connected == null) {
			line.enabled = false;
		}
		else
		{
			line.enabled = true;
			line.SetPosition(0, line.transform.position);
			line.SetPosition(1, connected.line.transform.position);
			line.SetColors(l.color, connected.l.color);
		}
	}
}
