using UnityEngine;
using System.Collections;
using Lidgren.Network;

public class MockClient : MonoBehaviour, IClient {

	public void connectToServer(string host, int port, NetOutgoingMessage auth) {

	}

	public void disconnectFromServer() {

	}

	public void sendUpdateState(Transform transform, Target target) {

	}

	public void receiveMessages() {

	}
}
