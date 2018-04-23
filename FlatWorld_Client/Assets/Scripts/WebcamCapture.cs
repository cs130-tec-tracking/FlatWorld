using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamCapture : MonoBehaviour 
{
	public WebCamTexture m_WebCamTexture;
	public Material Image_Material;

	// Use this for initialization
	void Start () {
		m_WebCamTexture = new WebCamTexture( 512, 512 );
		Image_Material.mainTexture = m_WebCamTexture;
		m_WebCamTexture.Play();	
	}
}
