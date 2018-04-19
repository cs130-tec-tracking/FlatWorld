using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FlatWorld.Enumerators;

namespace FlatWorld.Characters {

	public class Character
	{
		public List<int> Attribute_Current;
		public List<string> Armor, Skills, Weapons, Inventory, Advancements;


		public Character ( )
		{
			Attribute_Current = new List<int>( new int[]{ 0,0,0,0,0,0 } );
			Armor = new List<string>( );
			Skills = new List<string>( );
			Weapons = new List<string>( );
			Inventory = new List<string>( );
		}

		// Special "class based" abilities here
		public int Weapon_Speed_Mod = 2;


		//TODO: Finish allocating advancements!
		public void PopulateAdvancements ( CharacterClass character_class )
		{
			Advancements = new List<string>( );
			switch ( character_class )
			{
			case CharacterClass.Fighter:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			case CharacterClass.Ranger:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			case CharacterClass.Thief:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			case CharacterClass.Bard:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			case CharacterClass.Wizard:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				AddGainItemsAdvancements( new string[]{ "Learn DARK", "Learn DIE", "Learn LIFT", "Learn GLOW", "Learn RUST" } );
				break;
			case CharacterClass.Shair:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			case CharacterClass.Cleric:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			case CharacterClass.Paladin:
				AddIncreasedAttributesAdvancements( 7,5,5,3,4,4 );
				break;
			}
		}

		public void AddGainItemsAdvancements ( string[] item_names )
		{
			for ( int i = 0; i < item_names.Length; i++ ) { Advancements.Add( item_names[ i ] ); }
		}

		public void AddIncreasedAttributesAdvancements ( int _str, int _dex, int _con, int _int, int _wis, int _cha )
		{
			MultipleAdvancements( _str, "Increase Strength" );
			MultipleAdvancements( _dex, "Increase Dexterity" );
			MultipleAdvancements( _con, "Increase Constitution" );
			MultipleAdvancements( _int, "Increase Intelligence" );
			MultipleAdvancements( _wis, "Increase Wisdom" );
			MultipleAdvancements( _cha, "Increase Charisma" );
		}

		public void MultipleAdvancements ( int num, string name )
		{
			for ( int i = 0; i < num; i++ ) { Advancements.Add( name ); }
		}


		public bool GetAttributeRoll ( Attribute key_attribute, int skill_mod )
		{
			int roll = Random.Range( 1, 21 );
			Debug.Log( "Character rolled and got " + roll );
			if ( roll < Attribute_Current[ (int)key_attribute ] - skill_mod && roll != 20 ) {
				return true;
			}
			return false;
		}
	}


}