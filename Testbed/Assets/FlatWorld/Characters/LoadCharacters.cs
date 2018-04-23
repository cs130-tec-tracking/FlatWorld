using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FlatWorld.Characters;

public class LoadCharacters : MonoBehaviour 
{
	public string Character_List;

	public List<Character> All_Characters;
	private void Awake ( )
	{
		All_Characters = new List<Character>( );
		//Character character = new Character( ):

		Debug.Log( Application.streamingAssetsPath + Character_List );
		string[] character_names = System.IO.File.ReadAllLines( Application.streamingAssetsPath + Character_List );
		foreach ( string character_name in character_names )
		{
			//All_Characters.Add( new Character( character_name ) );

		}
	}
}
