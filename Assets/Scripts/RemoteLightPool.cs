﻿using UnityEngine;
using System.Collections;

public class RemoteLightPool : MonoBehaviour {

	public int maxRemotePlayers = 5000;
	public GameObject remotePrefab;
	static GameObject[] pool;

	void Awake() {
		pool = new GameObject[maxRemotePlayers];

		for (int i = 0; i < maxRemotePlayers; i++) {
			pool[i] = (GameObject)Instantiate(remotePrefab);
			pool[i].transform.parent = this.transform;
			pool[i].SetActive(false);
		}
	}

	public static GameObject UpdateNetworkPlayer(int id, float x, float y) {
		if (id >= pool.Length) return null;

		GameObject netPlayer = pool[id];
		netPlayer.SetActive(true);
		netPlayer.GetComponent<RemoteLightController>().setGoalPosition(x,y);
		return netPlayer;
	}

	public static void DeactivateNetworkPlayer(int id) {
		if (id >= pool.Length) return;

		pool[id].SetActive(false);
	}
}
