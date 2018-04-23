using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamDisplay : MonoBehaviour 
{
	public WebCamTexture m_WebCamTexture;
	public Material Image_Material;

	// Use this for initialization
	void Start () {
		m_WebCamTexture = new WebCamTexture( );
		Image_Material.mainTexture = m_WebCamTexture;
		m_WebCamTexture.Play();	
	}
	

}


//https://answers.unity.com/questions/1349462/unity-simple-client-server-video-streaming-using-r.html
//https://stackoverflow.com/questions/42717713/unity-live-video-streaming
//https://answers.unity.com/questions/190340/how-can-i-send-a-render-texture-over-the-network.html