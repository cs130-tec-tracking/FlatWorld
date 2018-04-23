using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkClient : MonoBehaviour 
{
	public WebcamCapture m_WebcamCapture;

	private int Host_ID, Connection_ID, Reliable_Channel_ID;
	private Texture2D Temp_Image;

	private void Start ( )
	{
		NetworkTransport.Init( );
		ConnectionConfig cc = new ConnectionConfig( );
		Reliable_Channel_ID = cc.AddChannel( QosType.Reliable );
		cc.PacketSize = 1470;
		cc.MinUpdateTimeout = 1;
		cc.SendDelay = 10;
		cc.BandwidthPeakFactor = 10;
		cc.InitialBandwidth = 1536000;
		cc.FragmentSize = 220;
		cc.MaxSentMessageQueueSize = 250;

		Temp_Image = new Texture2D( m_WebcamCapture.m_WebCamTexture.width, m_WebcamCapture.m_WebCamTexture.height);
	}

	private float Next_Frame = 0.0f;

	void Update () 
	{
		if ( Time.time > Next_Frame ) {
			Next_Frame = Time.time + 1.0f;
			SendWebcamTexture( );
		}
	}
	private void SendWebcamTexture ( )
	{
		Temp_Image.SetPixels32( WebcamCapture.m_WebCamTexture.GetPixels32( ) );
		byte[] buffer = Temp_Image.EncodeToPNG( );
		byte error;
		NetworkTransport.Send( Host_ID, Connection_ID, Reliable_Channel_ID, buffer, buffer.Length, out error ); 
		//NetworkTransport.Send( hostId, connectionId, myReiliableChannelId, buffer, bufferLength,  out error);
	}
}
