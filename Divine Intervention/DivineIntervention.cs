using XRL.Wish;
using XRL.World;
using XRL;
using static XRL.XRLGame;
using static XRL.The;
using static XRL.World.GameObject;

[HasWishCommand]
public static class Ashe_DivineIntervention_Handler
{
    public const string WISH_NAME = "divineintervention";

   [WishCommand(Command = WISH_NAME)]
    public static bool HandleWish()
    {
		The.Player.RestorePristineHealth();
		return true;
    }
}
