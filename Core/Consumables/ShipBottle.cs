using DiskCardGame;
using EasyFeedback.APIs;
using GrimoraMod.Extensions;
using InscryptionAPI.Items;
using InscryptionAPI.Items.Extensions;
using System;
using System.Collections;
using System.Resources;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Tilemaps;
using  static GrimoraMod.GrimoraPlugin;

namespace GrimoraMod.Consumables;

public class ShipBottle : ConsumableItem
{



	public override IEnumerator ActivateSequence()
	{
		Debug.Log("Using Ship Bottle");

		base.PlayExitAnimation();
		yield return new WaitForSeconds(0.25f);
		Singleton<ViewManager>.Instance.SwitchToView(View.Board, false, false);
		yield return new WaitForSeconds(0.2f);

		List<CardSlot> slots = ValidSlots();

		List<String> PirateNames = new List<String> { "Browntooth Barrie", "Bonnie Splinter", "Freebooter Bethel", "Crazy Oakes Hayward", "Ashton Swabby", "Plankton Braxton", "Yeller-eye Colby", "Fishwife Nate", "Four-finger Fred", "Dawg Julie", "Wicked Jones", "Crabby Steele" };


		foreach (CardSlot cardSlot in slots)
		{
			CardInfo NewSkeleton = CardLoader.GetCardByName(NameSkeleton);

			String namepick = PirateNames.GetRandomItem();

			PirateNames.Remove(namepick);

			NewSkeleton.displayedName = namepick;
			NewSkeleton.baseAttack += 1;
			yield return Singleton<BoardManager>.Instance.CreateCardInSlot(NewSkeleton, cardSlot, 0.25f, true);
			yield return new WaitForSeconds(0.1f);

		}

		yield return new WaitForSeconds(0.5f);
	}

	private static List<CardSlot> ValidSlots()
	{
		List<CardSlot> slots = new(Singleton<BoardManager>.Instance.AllSlots);

		slots.RemoveAll((a) => a.Card != null);
		return slots;


	}

	public static ConsumableItemData NewShipBottle(GameObject Model)
	{
		Debug.Log("Added Ship Bottle");

		Texture2D HahaL = new Texture2D(70, 80);
		ConsumableItemData data = ConsumableItemManager.New(GUID, "Ship Bottle", "The Ship in a Bottle, fills the entire board with a scurvy Skeleton Crew.", HahaL, typeof(ShipBottle), Model)
					.SetLearnItemDescription("Fills the entire board with skeletons! Like a real Pirate, Royal would be proud.");
		data.rulebookCategory = AbilityMetaCategory.GrimoraRulebook;

		return data;
	}
}
