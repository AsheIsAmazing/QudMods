using System;
using XRL.UI;
using static XRL.UI.Popup;  // Show
using XRL.World;
using static XRL.World.Cell;
using XRL;
using static XRL.XRLGame;
using static XRL.The;
using System.Collections.Generic;
using XRL.Wish;

[HasWishCommand]
public static class Ashe_LongSwap_Handler
{
    public const string WISH_NAME = "longswap";

    [WishCommand(Command = WISH_NAME)]
    public static bool HandleWish()
    {
		Cell cell = The.Player.Physics.PickDestinationCell(9999, AllowVis.OnlyVisible, Locked: true, IgnoreSolid: false, IgnoreLOS: true, RequireCombat: true, PickTarget.PickStyle.EmptyCell, "Swap with whom?", Snap: true);
		if (cell == null)
		{
			return false;
		}
		List<XRL.World.GameObject> objectsWithPart = cell.GetObjectsWithPart("Combat");
		if (objectsWithPart.Count <= 0)
		{
			Show("There are no valid targets in that square.");
		}
		else
		{
			The.Game.Player.Body = objectsWithPart[0];
		}
		return true;
    }
}