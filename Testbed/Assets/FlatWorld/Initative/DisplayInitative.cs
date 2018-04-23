using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInitative : MonoBehaviour 
{
	public List<DisplayRow> m_Rows;

	public void Reset ( )
	{
		foreach ( DisplayRow row in m_Rows ) { row.Reset( ); }
	}

	public void AddBlock ( int row, Texture2D character_icon )
	{
		m_Rows[ row ].AddBlock( character_icon ); 
	}
}
