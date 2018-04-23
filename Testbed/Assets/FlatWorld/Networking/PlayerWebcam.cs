using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerWebcam : NetworkBehaviour 
{
	private const int MAX_CONNECTION = 6;
	private int port = 5701;

	private int hostId, webHostId;
	private int reliableChannel, unreliableChannel, fragmentedReliableChannel, fragmentedUnreliableChannel;

	private bool isConnected = false, isStarted = false;
	private byte error;

	private void Start ( )
	{
		Connect( );
	}

	public void Connect ( )
	{
		NetworkTransport.Init( );

		GlobalConfig global_config = new GlobalConfig( );
		//global_config.MaxPacketSize = 

		ConnectionConfig cc = new ConnectionConfig( );
		reliableChannel = cc.AddChannel( QosType.Reliable );
		unreliableChannel = cc.AddChannel(QosType.Unreliable);
		fragmentedReliableChannel = cc.AddChannel(QosType.ReliableFragmented);
		fragmentedUnreliableChannel = cc.AddChannel(QosType.UnreliableFragmented);
		cc.PacketSize = 1470;
		cc.MinUpdateTimeout = 1; 
		cc.SendDelay = 10;
		cc.BandwidthPeakFactor = 100;
		cc.InitialBandwidth = 1536000;        // this is the most important parameter
		cc.FragmentSize = 220;
		cc.MaxSentMessageQueueSize = 250;

		HostTopology topology = new HostTopology( cc, MAX_CONNECTION );

		hostId = NetworkTransport.AddHost( topology, port, null );
		webHostId = NetworkTransport.Connect( hostId, port, null );

		isStarted = true;
	}

	private void Update ( )
	{
		if ( !isStarted ) {
			return;
		}

		int recHostId;
		int connectionId;
		int channelId;
		byte[] recBuffer = new byte[1024];
		int bufferSize = 1024;
		int dataSize;
		byte error;
		NetworkEventType recData = NetworkTransport.Receive( out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize out error );
		switch ( recData ) 
		{
			case NetworkEventType.Nothing: //1
				break;
			case NetworkEventType.ConnectEvent: //2
				break;
			case NetworkEventType.DataEvent: //3
				break;
			case NetworkEventType.DisconnectEvent: //4
				break;
		}
	}

	private void Update ( ) 
	{
	}
}
