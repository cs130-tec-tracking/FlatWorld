using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FlatWorld.Characters;

public class InitativeTracker : MonoBehaviour 
{
	public DisplayInitative m_DisplayInitative;
	public Dictionary<int, List<string>> Initative_Track;
	public Dictionary<string, int> Initative_Index;
	public int Current_Initative;

	private void Awake ( )
	{
		Current_Initative = 0; 
		Initative_Track = new Dictionary<int, List<string>>( );
	}

	public bool TEST_INITATIVE = false;
	private void Start ( )
	{
		if ( TEST_INITATIVE ) {
			List<string> characters = new List<string>( );
			characters.Add( "Mikal" );
			Initative_Track.Add( 2, characters );

		}
	}

	public void AddCharacterAtPosition ( int initative_mod, string character_name )
	{
		int current_index;
		if ( Initative_Index.ContainsKey( character_name ) ) {
			Debug.Log( "Character already exists in initative" );
			current_index = Initative_Index[ character_name ];
			Initative_Track[ current_index ].Remove( character_name );
			return;
		}

		current_index = Current_Initative + initative_mod;
		Initative_Index.Add( character_name, current_index );
		Initative_Track[ current_index ].Add( character_name );
	}

	private string ReturnNextCharacter ( )
	{
		return Initative_Track[ Current_Initative ][ 0 ];
	}

	private void MoveToNext ( ) 
	{
		Current_Initative++;
		DisplayInitative( );
	}

	private void DisplayInitative ( )
	{
		m_DisplayInitative.Reset( );
		for ( int i = 0; i < 10; i++ ) {
			foreach ( string character_name in Initative_Track[ Current_Initative + i ] ) {
				// Display a block at the initative height
				m_DisplayInitative.AddBlock( Current_Initative + i, RunGame.m.GetImageForCharacter( character_name ) );
			}
		}
	}

}
