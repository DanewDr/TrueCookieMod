using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CookieMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CookieHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cookie Hood");
			Tooltip.SetDefault("#putyourhelmetonhappy\n(Throwing)");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 2500;
			item.rare = 2;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CookieBreastplate") && legs.type == mod.ItemType("CookieLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increased Throwing Damage";
			player.thrownDamage *= 1.09f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Cookie", 25);
			recipe.AddTile(null, "CookieWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
