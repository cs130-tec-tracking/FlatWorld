using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FlatWorld.Enumerators;
using FlatWorld.Advancements;
using FlatWorld.Characters;
using FlatWorld.Items;

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
		// Melee Weapons
		All_Weapons.Add( "Dagger",     new Weapon( new Vector3(  1,  1, 3 ), 4, 0,  5,   false, "stab"   ) );
		All_Weapons.Add( "Club",       new Weapon( new Vector3(  5,  1, 4 ), 6, 0,  5,   true,  "thwack" ) );
		All_Weapons.Add( "Spear",      new Weapon( new Vector3(  3,  1, 4 ), 6, 0, 10,   false, "stab"   ) );
		All_Weapons.Add( "Mace",       new Weapon( new Vector3( 10,  5, 5 ), 6, 1,  5,   true,  "thwack" ) );
		All_Weapons.Add( "Sword",      new Weapon( new Vector3(  3,  1, 4 ), 8, 0,  5,   false, "swing"  ) );
		All_Weapons.Add( "Claymore",   new Weapon( new Vector3( 15, 10, 5 ), 4, 4,  5,   false, "swing"  ) );

		// Ranged Weapons
		All_Weapons.Add( "Sling",      new Weapon( new Vector3(  2,  1, 3 ), 4, 0,   5,  false, "twirl"  ) );
		All_Weapons.Add( "Short Bow",  new Weapon( new Vector3(  5, 15, 4 ), 6, 0,  60,  false, "twang"  ) );
		All_Weapons.Add( "Long Bow",   new Weapon( new Vector3(  7, 30, 4 ), 6, 1, 120,  false, "twang"  ) );
		All_Weapons.Add( "Crossbow",   new Weapon( new Vector3( 10, 25, 6 ), 8, 1,  90,  true,  "twang"  ) );

		// Armor class starts at 10 (50% crit chance against you) and goes down to 0 (0% crit chance) 
		// so undead have an armor class of 0, immune to crit, but not immune to damage. So simple!
		All_Armor = new Dictionary<string, Armor>( );
		/*
		All_Armor.Add( "Cloth Tabard",        new Armor(  2, 0, -1, "body"  ) );
		All_Armor.Add( "Cloth Leggings",      new Armor(  2, -1, "legs"  ) );
		All_Armor.Add( "Cloth Cap",           new Armor(  1,  0, "head"  ) );
		All_Armor.Add( "Cloth Gloves",        new Armor(  1,  0, "hands" ) );
		All_Armor.Add( "Cloth Boots",         new Armor(  1,  0, "feet"  ) );

		All_Armor.Add( "Animal Hides",        new Armor(  10, -3, "body" ) );

		All_Armor.Add( "Padded Leather",      new Armor( 10, -3, "body" ) );

		All_Armor.Add( "Studded Leather",     new Armor( 0, -4, "body" ) );

		All_Armor.Add( "Ringmail Coat",       new Armor( 0, -5, "body" ) );

		All_Armor.Add( "Chainmail Coat",      new Armor( 15, -3, "body"  ) );
		All_Armor.Add( "Chainmail Leggings",  new Armor(  7, -2, "legs"  ) );
		All_Armor.Add( "Chainmail Coif",      new Armor(  3, -1, "head"  ) );
		All_Armor.Add( "Chainmail Gauntlets", new Armor(  3,  0, "hands" ) );
		All_Armor.Add( "Chainmail Boots",     new Armor(  7,  0, "feet"  ) );

		All_Armor.Add( "Bandedmail Coat",     new Armor(  0, -7, "body" ) );
		All_Armor.Add( "Bandedmail Leggings", new Armor(  0, -7, "body" ) );

		All_Armor.Add( "Scalemail Coat",     new Armor( 0, -7, "body" ) );
		All_Armor.Add( "Scalemail Leggings", new Armor( 0, -1, "legs" ) );
		// great helm
		// NO PLATE ARMOR! Its too heavy
*/
		All_Skills = new Dictionary<string, Skill>( );
/*
		All_Skills.Add( "LockPick", new Skill( ) );
*/
		All_Spells = new Dictionary<string, Spell>( );
/*
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

*/
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
		/*
		All_Shields.Add( "Wooden Buckler", new Shield( 3 ) );
		All_Shields.Add( "Hide Buckler",   new Shield( 5 ) );
		All_Shields.Add( "Metal Buckler",  new Shield( 7 ) );

		All_Shields.Add( "Hide Shield",   new Shield( 5 ) );
		All_Shields.Add( "Tower Shield",  new Shield( 15 ) );
*/

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

