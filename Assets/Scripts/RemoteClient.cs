using UnityEngine;
using System.Collections;
using Lidgren.Network;

enum PlayerCommands : byte
{
	UserReport, Update, Disconnect
}

public enum PlayerColours : byte
{
	Red, Blue, Green, White
}

public class RemoteClient : IClient {

	public string host;
	public int port;
	public string code;

	NetClient m_client;
	NetIncomingMessage inc;

	public override void connectToServer() {
		NetPeerConfiguration config = new NetPeerConfiguration("StellationServer");
		m_client = new NetClient(config);
		m_client.Start();

		NetOutgoingMessage auth = m_client.CreateMessage();
		auth.Write (code);

		m_client.Connect (host, port, auth);
	}
	
	public override void disconnectFromServer() {
		NetOutgoingMessage msg = m_client.CreateMessage();
		msg.Write(false);
		msg.Write((byte)PlayerCommands.Disconnect);

		m_client.SendMessage(msg, NetDeliveryMethod.ReliableUnordered);
	}
	
	public override void sendUpdateState(LightController l) {
		NetOutgoingMessage msg = m_client.CreateMessage();
		msg.Write(false);
		msg.Write((byte)PlayerCommands.Update);
		msg.Write(l.t.position.x);
		msg.Write(l.t.position.y);
		msg.Write((byte)l.colour);
		
		m_client.SendMessage(msg, NetDeliveryMethod.UnreliableSequenced);
	}
	
	public override void receiveMessages() {
		while ((inc = m_client.ReadMessage()) != null)
		{
			switch (inc.MessageType)
			{
			case NetIncomingMessageType.Data:
				switch ((PlayerCommands)inc.ReadByte()) 
				{
				case PlayerCommands.Update:
					RemoteLightPool.UpdateNetworkPlayer(inc.ReadInt32(), inc.ReadFloat(), inc.ReadFloat(), (PlayerColours)inc.ReadByte());
					break;
				case PlayerCommands.Disconnect:
					RemoteLightPool.DeactivateNetworkPlayer(inc.ReadInt32());
					break;
				}
				break;
			default:
				break;
			}
		}
	}

	void Start() {
		connectToServer();
	}

	void Update() {
		receiveMessages();
	}
}
