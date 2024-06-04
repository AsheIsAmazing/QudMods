using System;
using XRL;
using XRL.Rules;
using XRL.World;
using XRL.World.Parts;

public class Ashe_ExtradimensionalInventory2 : IPart
{
	public int Chance = 100;
	
	public int WaresChance = 100;

	public bool Applied;

	public override bool WantEvent(int ID, int cascade)
	{
		if (!base.WantEvent(ID, cascade) && ID != PooledEvent<StockedEvent>.ID)
		{
			return ID == EnteredCellEvent.ID;
		}
		return true;
	}
	
	public override bool HandleEvent(EnteredCellEvent E)
	{
		if (!Applied)
		{
			Apply();
			if (!ParentObject.HasPart(typeof(GenericInventoryRestocker)))
			{
				ParentObject.RemovePart(this);
			}
		}
		return base.HandleEvent(E);
	}

	public override bool HandleEvent(StockedEvent E)
	{
		Apply();
		return base.HandleEvent(E);
	}

	public void Apply()
	{
		Applied = true;
		foreach (GameObject item in ParentObject.GetInventory())
		{
			if (!item.HasPart<ModExtradimensional>() && Stat.Random(1, 100) <= Chance && !(item.GetTag("Mods") == "None"))
			{
				item.AddPart(new ModExtradimensional());
				if (WaresChance.in100())
				{
					item.SetIntProperty("_stock", 1);
				}
			}
		}
	}
}