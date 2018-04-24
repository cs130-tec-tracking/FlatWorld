using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamCapture : MonoBehaviour 
{
	public WebCamTexture m_WebCamTexture;
	public Material Image_Material;

	public int WEBCAM_DIMENSIONS;

	private void Awake () 
	{
		WEBCAM_DIMENSIONS= 256;

		m_WebCamTexture = new WebCamTexture( WEBCAM_DIMENSIONS, WEBCAM_DIMENSIONS );
//e		m_WebCamTexture..width = WEBCAM_DIMENSIONS;
//		m_WebCamTexture.height = WEBCAM_DIMENSIONS;
		Image_Material.mainTexture = m_WebCamTexture;
	}
	private void Start ( )
	{
		m_WebCamTexture.Play();	
	}
}
