using System;
using XRL.UI;
using XRL.World;
using XRL;
using static XRL.UI.Popup;
using static XRL.XRLGame;
using static XRL.The;
using System.Collections.Generic;
using XRL.Wish;
using XRL.Messages;
using static XRL.World.GameObject;
using XRL.World.Parts;
using static XRL.World.Parts.ActivatedAbilities;
using static XRL.World.Parts.ActivatedAbilityEntry;

[HasWishCommand]
public static class Ashe_RemoveAbility_Handler
{
    public const string WISH_NAME = "removeability";

   [WishCommand(Command = WISH_NAME)]
    public static bool RemoveAbility(string abilityname)
    {
		var ability = The.Player.GetActivatedAbilityByCommand(abilityname);
		if (ability == null)
		{
			Show("Ability not found. Please use the command name.");
		}
		else
		{
			The.Player.RemoveActivatedAbilityByCommand(abilityname);
			Show("Removed activated ability " + ability + " from player body.");
		}
		return true;
    }
}