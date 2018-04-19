using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlatWorld.Enumerators
{
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
}