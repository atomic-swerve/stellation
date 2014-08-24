using UnityEngine;
using System.Collections;

public class ColourChanger : MonoBehaviour {

	public PlayerColours colour;

	void OnTriggerEnter2D(Collider2D coll) {
		LightController target;

		if ((target = coll.GetComponent<LightController>()) != null) {
			target.setColourState(colour);
		}
	}
}
