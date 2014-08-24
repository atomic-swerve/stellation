using UnityEngine;
using System.Collections;
using Lidgren.Network;

public class MockClient : IClient {

	public override void connectToServer() {

	}

	public override void disconnectFromServer() {

	}
	
	public override void sendUpdateState(Transform transform) {
		
	}

	public override void sendUpdateColour(PlayerColours c) {
		
	}

	public override void receiveMessages() {

	}
}
