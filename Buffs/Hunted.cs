
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace aberration.Buffs
{
	public class Hunted : ModBuff
	{
		public override void SetDefaults() {
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
			DisplayName.SetDefault("Hunted");
			Description.SetDefault("You feel like you are being watched");
		}
		
		
		public override void Update(Player player, ref int buffIndex) {
			if(player.buffTime[buffIndex]<10){
				player.buffTime[buffIndex] = -1;
				NPC.SpawnOnPlayer(player.whoAmI,NPCType<NPCs.Hunter>());
			}
			
		}
		
		
	}
}