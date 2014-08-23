using UnityEngine;
using System.Collections;
using Lidgren.Network;

public interface IClient {
	void connectToServer(string host, int port, NetOutgoingMessage auth);
	void disconnectFromServer();
	void sendUpdateState(Transform transform, Target target);
	void receiveMessages();
	
}
