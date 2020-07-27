using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace aberration.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class Watcher : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Watcher");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.WalkingAntlion];
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 1;
			npc.defense = 12;
			npc.lifeMax = 72;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
			animationType = NPCID.WalkingAntlion;
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
		}
		public override void OnHitPlayer	(Player target,int damage,bool crit){
			target.AddBuff(mod.BuffType("Hunted"),Main.rand.Next(120, 2400));
			npc.life = 0;
			npc.StrikeNPC(999,0.0f,0);
		}	
		
	}
}