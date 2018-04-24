using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class NetworkClient : MonoBehaviour 
{
	public WebcamCapture m_WebcamCapture;

	private int Host_ID, Connection_ID, Reliable_Channel_ID;
	private Texture2D Temp_Image;

	public Material Temp_View;

	private void Start ( )
	{
		NetworkTransport.Init( );
		ConnectionConfig cc = new ConnectionConfig( );
		Reliable_Channel_ID = cc.AddChannel( QosType.ReliableSequenced );
		cc.PacketSize = 1470;
		cc.MinUpdateTimeout = 1;
		cc.SendDelay = 10;
		cc.BandwidthPeakFactor = 10;
		cc.InitialBandwidth = 1536000;
		cc.FragmentSize = 220;
		cc.MaxSentMessageQueueSize = 250;

		HostTopology topology = new HostTopology( cc, 6 );
		Host_ID = NetworkTransport.AddHost( topology );

		byte error;
		NetworkTransport.ConnectToNetworkPeer( Host_ID, Relay_IP, Relay_Port, 0, 0, 

		Debug.LogWarning( m_WebcamCapture.m_WebCamTexture.width + " X " + m_WebcamCapture.m_WebCamTexture.height );
		Temp_Image = new Texture2D( m_WebcamCapture.m_WebCamTexture.width, m_WebcamCapture.m_WebCamTexture.height);
		Temp_View.mainTexture = Temp_Image;

	}

	private float Next_Frame = 0.0f;
	public float Time_diff = 0.1f;

	void Update () 
	{
		if ( Time.time > Next_Frame ) {
			Next_Frame = Time.time + Time_diff;
			SendWebcamTexture( );
		}
	}
	public bool RESIZE = false;
	public bool REALLY_SEND = true;

	byte[] Int_To_Bytes ( int i )
	{
		byte[] result = new byte[4];
		result[ 0 ] = (byte)( i >> 24 );
		result[ 1 ] = (byte)( i >> 16 );
		result[ 2 ] = (byte)( i >> 8 );
		result[ 3 ] = (byte)( i /*>> 0*/ );
		return result;
	}

	private void SendWebcamTexture ( )
	{
		if ( RESIZE ) {
			Temp_Image.Resize( m_WebcamCapture.m_WebCamTexture.width, m_WebcamCapture.m_WebCamTexture.height );
			Temp_Image.Apply( );
		}

		Temp_Image.SetPixels32( m_WebcamCapture.m_WebCamTexture.GetPixels32( ) );
		if ( RESIZE ) {
			Temp_Image.Resize( m_WebcamCapture.WEBCAM_DIMENSIONS, m_WebcamCapture.WEBCAM_DIMENSIONS );
		}
		Temp_Image.Apply( );
		Debug.LogWarning( Temp_Image.width + " X " + Temp_Image.height );

		if ( REALLY_SEND ) {
			byte[] buffer = Temp_Image.EncodeToPNG( );
			byte error;

			int num_chunks = Mathf.CeilToInt( (float)buffer.Length / 65527.0f );
			int remainder = Mathf.CeilToInt( (float)buffer.Length % 65527.0f );

			Debug.Log( "|" + buffer.Length + "| |" + num_chunks + "| chunks |" + remainder + "| remainder" );
			//byte[] temp_buffer = buffer.CopyTo( .Take( 50 );

			NetworkTransport.Send( Host_ID, Connection_ID, Reliable_Channel_ID, Int_To_Bytes( buffer.Length ), 4, out error ); 

			// Send all chunks of exactly 65527 length!
			byte[] temp_buffer = new byte[65527];
			for ( int i = 0; i < num_chunks - 1; i++ ) {
				System.Array.Copy( buffer, i * 65527, temp_buffer, 0, 65527 );
				NetworkTransport.Send( Host_ID, Connection_ID, Reliable_Channel_ID, temp_buffer, 65527, out error ); 
			}

			// Send the remainder!
			temp_buffer = new byte[ remainder ];
			System.Array.Copy( buffer, (num_chunks - 1) * 65527, temp_buffer, 0, remainder );
			NetworkTransport.Send( Host_ID, Connection_ID, Reliable_Channel_ID, temp_buffer, remainder, out error ); 



		}

		//NetworkTransport.Send( Host_ID, Connection_ID, Reliable_Channel_ID, buffer, buffer.Length, out error ); 
		//NetworkTransport.Send( hostId, connectionId, myReiliableChannelId, buffer, bufferLength,  out error);
	}
}
