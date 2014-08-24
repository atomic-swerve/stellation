using UnityEngine;
using System.Collections;
using Lidgren.Network;

public abstract class IClient : MonoBehaviour {
	public abstract void connectToServer();
	public abstract void disconnectFromServer();
	public abstract void sendUpdateState(LightController l);
	public abstract void receiveMessages();
	
}
