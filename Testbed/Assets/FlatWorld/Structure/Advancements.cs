using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FlatWorld.Enumerators;
using FlatWorld.Characters;

namespace FlatWorld.Advancements
{
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


}