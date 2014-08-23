using UnityEngine;
using System.Collections;
using Lidgren.Network;

public abstract class IClient : MonoBehaviour {
	public abstract void connectToServer(string host, int port, NetOutgoingMessage auth);
	public abstract void disconnectFromServer();
	public abstract void sendUpdateState(Transform transform, Target target);
	public abstract void receiveMessages();
	
}
