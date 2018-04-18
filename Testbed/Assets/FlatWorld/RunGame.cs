using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Possible_Actions
{
	Movement = 0,
	Weapon_Attack,
	Cast_Spell,
	Use_Skill,
	EquipItem
}

public enum Attribute
{
	Strength = 0, // Hit chance, Tests of Strength
	Dexterity,    // Armor Class, Starting Initative
	Constitution, // Hit points, System Shock
	Intelligence, // Skills Known, Magical Affinity
	Wisdom,       // Saving Throws, Perception "sixth sense"
	Charisma      // Henchmen, Reaction
}

public enum CharacterClass
{
	Fighter = 0,
	Ranger,
	Thief,
	Bard,
	Wizard,
	Shair,
	Cleric,
	Paladin
}

public class Advancement
{
	public virtual void ApplyAdvancement ( Character character ) { }
}

public class IncreaseAttribute : Advancement
{
	public Attribute Key_Attribute;

	public IncreaseAttribute ( Attribute key_attribute )
	{
		Key_Attribute = key_attribute;
	}

	public override void ApplyAdvancement ( Character character ) 
	{
		character.Attribute_Current[ (int)Key_Attribute ] = character.Attribute_Current[ (int)Key_Attribute ] + 1;
	}
}

public class GainItem : Advancement
{
	public string Item_Name;

	public GainItem ( string item_name )
	{
		Item_Name = item_name;
	}

	public override void ApplyAdvancement ( Character character ) 
	{
		character.Inventory.Add( Item_Name );
	}
}

public class NPC : Character
{
	public string Name;
}

public class Henchmen : NPC
{

}

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
		for ( int i = 0; i < _str; i++ ) { Advancements.Add( "Increase Strength" ); }
		for ( int i = 0; i < _dex; i++ ) { Advancements.Add( "Increase Dexterity" ); }
		for ( int i = 0; i < _con; i++ ) { Advancements.Add( "Increase Constitution" ); }
		for ( int i = 0; i < _int; i++ ) { Advancements.Add( "Increase Intelligence" ); }
		for ( int i = 0; i < _wis; i++ ) { Advancements.Add( "Increase Wisdom" ); }
		for ( int i = 0; i < _cha; i++ ) { Advancements.Add( "Increase Charisma" ); }
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

public class RunGame : MonoBehaviour 
{
	public Dictionary<string, Weapon> All_Weapons;
	public Dictionary<string, Armor> All_Armor;
	public Dictionary<string, Skill> All_Skills;
	public Dictionary<string, Spell> All_Spells;
	public Dictionary<string, Shield> All_Shields;
	public Dictionary<string, Advancement> All_Advancements;

	private void Awake( ) 
	{
		All_Weapons = new Dictionary<string, Weapon>( );
		All_Weapons.Add( "Dagger",     new Weapon( 4, 0, 3, 5,    false, "stab" ) );
		All_Weapons.Add( "Club",       new Weapon( 6, 0, 4, 5,    true, "thwack" ) );
		All_Weapons.Add( "Spear",      new Weapon( 6, 0, 4, 10,   false, "stab" ) );
		All_Weapons.Add( "Mace",       new Weapon( 6, 1, 5, 5,    true,  "thwack" ) );
		All_Weapons.Add( "Sword",      new Weapon( 8, 0, 4, 5,    false, "swing" ) );
		All_Weapons.Add( "Claymore",   new Weapon( 4, 4, 5, 5,    false, "swing" ) );

		All_Weapons.Add( "Sling",      new Weapon( 4, 0, 3, 5,    false, "twirl" ) );
		All_Weapons.Add( "Short Bow",  new Weapon( 6, 0, 4, 60,   false, "twang" ) );
		All_Weapons.Add( "Long Bow",   new Weapon( 6, 1, 4, 120,  false, "twang" ) );
		All_Weapons.Add( "Crossbow",   new Weapon( 8, 1, 6, 90,   true,  "twang" ) );

		All_Armor = new Dictionary<string, Armor>( );
		All_Armor.Add( "Cloth Tabard",     new Armor( 15, "body" ) );

		All_Skills = new Dictionary<string, Skill>( );
		All_Skills.Add( "LockPick", new Skill( ) );

		All_Spells = new Dictionary<string, Spell>( );
		// Level 1 General Spells
		All_Spells.Add( "DARK",      new Spell( 1, "DARK",   "" ) );
		All_Spells.Add( "DIE",       new Spell( 1, "DIE",    "Deal 1d4 damage to a single target." ) );
		All_Spells.Add( "GLOW",      new Spell( 1, "GLOW",   "" ) );

		// Level 1 Wizard spells
		All_Spells.Add( "KNOCK",     new Spell( 1, "", "" ) ); //open door 

		All_Spells.Add( "BLESS",     new Spell( 1, "BLESS",  "" ) );
		All_Spells.Add( "CURE",      new Spell( 1, "CURE",   "Target makes a poison or disease save." ) ); // normally save 1/hour or 1/day respectivly
		All_Spells.Add( "LIFT",      new Spell( 1, "LIFT",   "<r>Raises</r> a single object <b>1</b> foot off the ground." ) );
		All_Spells.Add( "RUST",      new Spell( 1, "RUST",   "" ) );
		All_Spells.Add( "SHIFT",     new Spell( 1, "SHIFT",  "Transforms caster into a creature with a natural attack." ) );
		All_Spells.Add( "TAME",      new Spell( 1, "TAME",   "1 animal becomes friendly." ) );

		All_Spells.Add( "BURN",      new Spell( 2, "", "" ) );
		All_Spells.Add( "CHILL",     new Spell( 1, "", "" ) );
		All_Spells.Add( "DETECT",    new Spell( 1, "", "" ) );
		All_Spells.Add( "PURIFY",    new Spell( 2, "", "" ) );
		All_Spells.Add( "OBSCURE",   new Spell( 3, "", "" ) );
		All_Spells.Add( "CHANT",     new Spell( 2, "", "" ) );
		All_Spells.Add( "PORTENT",   new Spell( 2, "", "" ) );
		All_Spells.Add( "DREAM",     new Spell( 3, "", "" ) );
		All_Spells.Add( "COMMUNE",   new Spell( 2, "", "" ) );
		All_Spells.Add( "STRIDE",    new Spell( 1, "", "" ) );

		All_Spells.Add( "PRAYER",    new Spell( 2, "", "" ) );
		All_Spells.Add( "SILENCE",   new Spell( 2, "", "" ) );
		All_Spells.Add( "PROTECT",   new Spell( 1, "", "" ) );
		All_Spells.Add( "ROOTS",     new Spell( 1, "", "" ) );
		All_Spells.Add( "EXORCISE",  new Spell( 1, "", "" ) );
		All_Spells.Add( "TONGUES",   new Spell( 1, "", "" ) );
		All_Spells.Add( "HIDE",      new Spell( 1, "", "" ) ); //invisibility
		All_Spells.Add( "HOLD",      new Spell( 2, "", "" ) );
		All_Spells.Add( "ADORE",     new Spell( 1, "", "" ) );
		All_Spells.Add( "TRICK",     new Spell( 1, "", "" ) ); // Hypnotism
		All_Spells.Add( "SOUND",     new Spell( 1, "", "" ) ); //audible glamour
		All_Spells.Add( "VANISH",    new Spell( 1, "", "" ) ); //invisibility
		All_Spells.Add( "SCARE",     new Spell( 1, "", "" ) ); //scare
		All_Spells.Add( "VEIL",      new Spell( 1, "", "" ) );
		All_Spells.Add( "BLUR",      new Spell( 1, "", "" ) );
		All_Spells.Add( "COLOR",     new Spell( 1, "", "" ) ); //color spray
		All_Spells.Add( "QUIET",     new Spell( 1, "", "" ) ); //you are quiet?
		All_Spells.Add( "WEB",       new Spell( 1, "", "" ) );
		All_Spells.Add( "TOAD",      new Spell( 1, "", "" ) );
		All_Spells.Add( "REVEAL",    new Spell( 1, "", "" ) );
		//All_Spells.Add( "BOLT",      new Spell( 1, "", "" ) );
		All_Spells.Add( "DANCE",     new Spell( 1, "", "" ) );
		All_Spells.Add( "FLOAT",     new Spell( 1, "", "" ) );
		All_Spells.Add( "FLIGHT",    new Spell( 1, "", "" ) );
		All_Spells.Add( "FIRE",      new Spell( 1, "", "" ) );
		All_Spells.Add( "ESCAPE",    new Spell( 1, "", "" ) );
		All_Spells.Add( "IGNITE",    new Spell( 1, "", "" ) );
		All_Spells.Add( "JOKE",      new Spell( 1, "", "" ) );
		All_Spells.Add( "RESTORE",   new Spell( 1, "", "" ) );
		All_Spells.Add( "RETURN",    new Spell( 1, "", "" ) );
		All_Spells.Add( "SLEEP",     new Spell( 1, "", "" ) );
		All_Spells.Add( "FORGET",    new Spell( 1, "", "" ) );
		All_Spells.Add( "ENLARGE",   new Spell( 1, "", "" ) );
		All_Spells.Add( "TRANSFORM", new Spell( 1, "", "" ) );
		All_Spells.Add( "SHOUT",     new Spell( 1, "", "" ) );
		All_Spells.Add( "SHIELD",    new Spell( 1, "", "" ) );
		All_Spells.Add( "SHATTER",   new Spell( 1, "", "" ) ); //power word kill
		All_Spells.Add( "GUST",      new Spell( 1, "", "" ) ); //feather fall
		All_Spells.Add( "IDENTIFY",  new Spell( 1, "", "" ) ); //read magic
		All_Spells.Add( "KNOW",      new Spell( 1, "", "" ) ); //comprehend 
		All_Spells.Add( "BREATH",    new Spell( 1, "", "" ) );
		All_Spells.Add( "SLOW",      new Spell( 1, "", "" ) );
		All_Spells.Add( "LORE",      new Spell( 1, "", "" ) ); //legend lore
/*
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
		All_Spells.Add( "", new Spell( 1, "", "" ) );
*/

		// A shield is a special item that allows you to force one attack against them to be rerolled. Each shield has a number of uses before it breaks.
		All_Shields = new Dictionary<string, Shield>( );
		All_Shields.Add( "Wooden Buckler", new Shield( 3 ) );


		All_Advancements = new Dictionary<string, Advancement>( );
		All_Advancements.Add( "Increase Strength", new IncreaseAttribute( Attribute.Strength ) );
		All_Advancements.Add( "Increase Dexterity", new IncreaseAttribute( Attribute.Dexterity ) );
		All_Advancements.Add( "Increase Constitution", new IncreaseAttribute( Attribute.Constitution ) );
		All_Advancements.Add( "Increase Intelligence", new IncreaseAttribute( Attribute.Intelligence ) );
		All_Advancements.Add( "Increase Wisdom", new IncreaseAttribute( Attribute.Wisdom ) );
		All_Advancements.Add( "Increase Charisma", new IncreaseAttribute( Attribute.Charisma ) );
		foreach ( KeyValuePair<string, Spell> spell_info in All_Spells ) { 
			All_Advancements.Add( "Learn " + spell_info.Key, new GainItem( spell_info.Key ) );
		}

	}

	public IEnumerator SyncWithServer ( string character_name, Character character )
	{
		string character_url = "www.frogknightgames.com/2e.php?char=" + character_name;

		if ( character != null ) {
			// Send data up to server
			WWWForm sync_form = new WWWForm( );

			string character_info = "";
			string[] character_attributes = new string[ character.Attribute_Current.Count ];
			for ( int i = 0; i < character.Attribute_Current.Count; i++ ) {
				character_attributes[ i ] = character.Attribute_Current[ i ].ToString( );
			}
			character_info += string.Join( ",", character_attributes ) + "|";
			character_info += string.Join( ",", character.Inventory.ToArray( ) );
			sync_form.AddField( "character_info", character_info );

			WWW sync = new WWW( character_url, sync_form );
			while ( !sync.isDone ) {
				yield return null;
			}

		} else {

			character = new Character( );

			WWW sync = new WWW( character_url );
			while ( !sync.isDone ) {
				yield return null;
			}

			string[] character_info = sync.text.Split( "|"[ 0 ] );
			string[] attributes = character_info[ 0 ].Split( ","[ 0 ] );
			int parse_target = 0;
			for ( int i = 0; i < character.Attribute_Current.Count; i++ ) {
				int.TryParse( attributes[ i ], out parse_target );
				character.Attribute_Current[ i ] = parse_target;
			}
			character.Inventory = new List<string>( character_info[ 1 ].Split( ","[ 0 ]) );
		}
	}
	
	public void PlayerTakesAction ( Character character, Possible_Actions taken_action, string details ) 
	{
		string new_event = "";
		if ( taken_action == Possible_Actions.Movement ) {

		} else if ( taken_action == Possible_Actions.Weapon_Attack ) {
			// Details is weather enemy is large or not
			Weapon current_weapon = All_Weapons[ character.Weapons[ 0 ] ];
			if ( current_weapon.HitEnemySuccess( character ) ) {
				new_event += "You " + current_weapon.Weapon_Attack_Type + " your mighy ";
				if ( string.IsNullOrEmpty( current_weapon.Weapon_Name ) ) {
					new_event += current_weapon.Weapon_Name;
				} else {
					new_event += character.Weapons[ 0 ];
				}
				new_event += " and hit, dealing " + current_weapon.DamageDealt( details == "large" ) + " points of damage.";
			}
			
		} else if ( taken_action == Possible_Actions.Cast_Spell ) {

		} else if ( taken_action == Possible_Actions.Use_Skill ) {
			new_event += All_Skills[ details ].Attempt( character );
		} else if ( taken_action == Possible_Actions.EquipItem ) {
			if ( character.Inventory.Contains( details ) ) {
				if ( All_Weapons.ContainsKey( details ) ) {
					character.Weapons[ 0 ] = details;
				} else if ( All_Armor.ContainsKey( details ) ) {
					Armor new_armor = All_Armor[ details ];
					int found_index = 0;
					for ( int i = 0; i < character.Armor.Count; i++ )
					{	
						if ( All_Armor[ character.Armor[ i ] ].Body_Slot == new_armor.Body_Slot )
						{
							found_index = i;
							break;
						}
					}
					character.Armor[ 0 ] = details;
				}
			} else {
				PrintEvent( "You do not have that item in your inventory" );
			}
		}

		PrintEvent( new_event );

	}

	public void PrintEvent ( string event_details )
	{
		Debug.Log( event_details );
	}
}

