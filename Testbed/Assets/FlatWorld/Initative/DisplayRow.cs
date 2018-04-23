using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRow : MonoBehaviour 
{
	public List<DisplayBlock> m_Blocks;

	public int Current_Block_Index;

	private void Awake ( )
	{
		Current_Block_Index = -1;
	}

	public void Reset ( )
	{
		Current_Block_Index = -1;
		foreach ( DisplayBlock block in m_Blocks ) { block.Reset( ); }
	}

	public void AddBlock ( Texture2D character_icon ) 
	{
		m_Blocks[ ++Current_Block_Index ].SetActiveWithIcon( character_icon );
	}
}
