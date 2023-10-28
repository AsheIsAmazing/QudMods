using HarmonyLib;
using XRL.World.Parts;

[HarmonyPatch(typeof(RandomAltarBaetyl))]
[HarmonyPatch("GetRandomRewardTypeInstance")]
class Ashe_BaetylPlus_Patch_RandomAltarBaetyl_GetRandomRewardTypeInstance
{
    static void Postfix(ref int __result)
    {
		if (__result == 4)
		{
		__result = RandomAltarBaetyl.GetRandomRewardTypeInstance();
		}
    }
}