namespace GrimoraMod;

public partial class GrimoraPlugin
{
	public const string NameDanseMacabre = $"{GUID}_DanseMacabre";

	private void Add_Card_DanseMacabre()
	{
		CardBuilder.Builder
			.SetAsNormalCard()
			.SetAbilities(AlternatingStrike.ability, Erratic.ability)
			.SetBaseAttackAndHealth(3, 3)
			.SetBoneCost(7)
			.SetDescription("FOREVER BOUND TOGETHER BY A TERRIBLE CURSE, THIS GROUP DANCES ONWARD INTO DOOM.")
			.SetNames(NameDanseMacabre, "Danse Macabre")
			.Build();
	}
}
