using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FlatWorld.Enumerators;
using FlatWorld.Characters;

namespace FlatWorld.Items
{
	public class Item
	{
		public int Use_Speed;

	}

	public class Equippable : Item
	{
		public int Strength_Requirement;

		public bool Can_Equip ( Character character )
		{
			if ( Strength_Requirement == 0 || character.Attribute_Current[ (int)Attribute.Strength ] > Strength_Requirement ) {
				return true;
			}
			return false;
		}

		public virtual bool Do_Equip ( Character character )
		{
			if ( Can_Equip( character ) ) {
				return true;
			}
			return false;
		}

	}

	public class Weapon : Equippable
	{
		public string Weapon_Name;
		public string Weapon_Attack_Type;
		public int Damage_Die;
		public int Damage_Mod;
		public int Reach_Value;
		public bool Ignore_DR;

		public Weapon ( int damage_die, int damage_mod, int use_speed, int reach_value, bool ignore_dr, string attack_type, string name = "" )
		{
			Damage_Die = damage_die;
			Damage_Mod = damage_mod;
			Use_Speed = use_speed;
			Reach_Value = reach_value;
			Ignore_DR = ignore_dr;
		}

		public bool HitEnemySuccess ( Character character )
		{
			return character.GetAttributeRoll( Attribute.Strength, 0 );
		}

		public int DamageDealt ( bool Enemy_large )
		{
			int damage_dealt = Random.Range( 1, Damage_Die ) + Damage_Mod;
			if ( Enemy_large && !Ignore_DR ) {
				return Mathf.Max(1, damage_dealt - 1 );
			}
			return damage_dealt;
		}

		public override bool Do_Equip ( Character character )
		{
			if ( Can_Equip( character ) ) {
				return true;
			}
			return false;
		}
	}


	public class Shield : Equippable
	{
		public int Block_Number;
		public Shield ( int block_number )
		{
			Block_Number = block_number;
		}
	}

	public class Armor : Equippable
	{
		public int Defense_Value;
		public string Body_Slot;
		public Armor ( int defense_value, string body_slot )
		{
			Defense_Value = defense_value;
			Body_Slot = body_slot;
		}
	}

	public class Skill : Item
	{
		public string Skill_Message;
		public Attribute Key_Attribute;
		public int Skill_Mod;

		public string Attempt ( Character character )
		{
			bool success = character.GetAttributeRoll( Key_Attribute, Skill_Mod );
			string attempt_message = Skill_Message;
			if ( success ) {
				attempt_message += ", and succeeded!";
			} else {
				attempt_message += ", and failed!";
			}
			return attempt_message;
		}
	}

	public class Spell : Item
	{
		public List<string> Spell_Letters;
		public int Spell_Level;
		public string Spell_Description;

		public Spell ( int spell_level, string spell_name, string spell_description )
		{
			Spell_Letters = new List<string>( );
			foreach ( char c in spell_name ) {
				Spell_Letters.Add( c.ToString( ) );
			}

			Spell_Level = spell_level;
			Use_Speed = Spell_Letters.Count;
			Spell_Description = spell_description;
		}
	}

}