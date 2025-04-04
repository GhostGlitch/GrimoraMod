using DiskCardGame;
using EasyFeedback.APIs;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers.Extensions;
using InscryptionAPI.Items;
using InscryptionAPI.Items.Extensions;
using System;
using System.Collections;
using System.Resources;
using System.Security.Policy;
using UnityEngine;
using  static GrimoraMod.GrimoraPlugin;

namespace GrimoraMod.Consumables;

public class Trowel : GrimoraTargetSlotItem
{



	public override string FirstPersonPrefabId => null;



	public override Vector3 FirstPersonItemPos => new Vector3(0f, -1f, 2.5f);

	public override Vector3 FirstPersonItemEulers => new Vector3(-60f, 0f, 0f);

	public override View SelectionView => View.Board;

	public override CursorType SelectionCursorType => CursorType.MoveUp;

	public override List<CardSlot> GetAllTargets()
	{
		return Singleton<BoardManager>.Instance.AllSlotsCopy;
	}

	public override List<CardSlot> GetValidTargets()
	{
		List<CardSlot> AllSlotsCopy = Singleton<BoardManager>.Instance.AllSlotsCopy;
		AllSlotsCopy.RemoveAll((CardSlot x) => x.Card != null);
		return AllSlotsCopy;
	}

	public override IEnumerator OnValidTargetSelected(CardSlot target, GameObject firstPersonItem)
	{

		List<String> PossibleCards = new List<String> { NameKennel, NameObol, NameDeadTree, NameDeadTree, NameShipwreck, NameShipwreck, NameDraugr, NameDraugr, NameSkeleton, NameObelisk, NameObelisk, NameVoodooDoll, NameVoodooDoll, NameDavyJonesLocker };

		yield return new WaitForSeconds(0.1f);

		yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(PossibleCards[UnityEngine.Random.Range(0, PossibleCards.Count-1)]), target, 0.25f, true);

		ViewManager.Instance.SwitchToView(View.BoneTokens, lockAfter: false);
		yield return new WaitForSeconds(0.4f);
		yield return ResourcesManager.Instance.AddBones(UnityEngine.Random.Range(1, 3));
		yield return new WaitForSeconds(0.4f);

		ViewManager.Instance.SetViewUnlocked();
	}






	public static ConsumableItemData NewTrowel(GameObject Model)
	{
		Debug.Log("Added Embalming Fluid");

		Texture2D HahaL = new Texture2D(70, 80);
		ConsumableItemData data = ConsumableItemManager.New(GUID, "Trowel", "The Trowel, dig up a random terrain and gain a few Bones.", HahaL, typeof(Trowel), Model)
							.SetLearnItemDescription("This used to belong to a gravedigger. Digs for treasure, or Terrain. And get some Bones too for your efforts.");
		data.rulebookCategory = AbilityMetaCategory.GrimoraRulebook;

		return data;
	}
}
