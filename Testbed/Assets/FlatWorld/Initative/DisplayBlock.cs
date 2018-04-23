using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBlock : MonoBehaviour 
{

	public UnityEngine.UI.Image m_Icon;

	public void Reset ( )
	{
		m_Icon.sprite = null;
	}

	public void SetActiveWithIcon ( Texture2D character_icon )
	{
		//m_Icon.sprite
	}

}
