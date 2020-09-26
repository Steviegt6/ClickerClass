using ClickerClass.Buffs;
using ClickerClass.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.NPCs
{
    public class ClickerGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool gouge = false;
        public bool frozen = false;
        public bool honeySlow = false;
        public bool embrittle = false;

        public override void ResetEffects(NPC npc)
        {
            gouge = false;
            frozen = false;
            honeySlow = false;
            embrittle = false;
        }

        public override void SetDefaults(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.SkeletronHead:
                case NPCID.SkeletronHand:
                case NPCID.SkeletronPrime:
                case NPCID.TheDestroyer:
                case NPCID.Retinazer:
                case NPCID.Spazmatism:
                case NPCID.EyeofCthulhu:
                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                case NPCID.QueenBee:
                case NPCID.WallofFlesh:
                case NPCID.WallofFleshEye:
                case NPCID.DukeFishron:
                case NPCID.BrainofCthulhu:
                case NPCID.Plantera:
                case NPCID.PrimeCannon:
                case NPCID.PrimeSaw:
                case NPCID.PrimeVice:
                case NPCID.PrimeLaser:
                case NPCID.Golem:
                case NPCID.GolemHead:
                case NPCID.GolemFistLeft:
                case NPCID.GolemFistRight:
                case NPCID.GolemHeadFree:
                case NPCID.CultistBoss:
                case NPCID.KingSlime:
                case NPCID.MoonLordHead:
                case NPCID.MoonLordHand:
                case NPCID.MoonLordCore:
                case NPCID.WyvernHead:
                case NPCID.WyvernLegs:
                case NPCID.WyvernBody:
                case NPCID.WyvernBody2:
                case NPCID.WyvernBody3:
                case NPCID.WyvernTail:
                case NPCID.IceGolem:
                case NPCID.Paladin:
                case NPCID.Everscream:
                case NPCID.IceQueen:
                case NPCID.SantaNK1:
                case NPCID.BigMimicCorruption:
                case NPCID.BigMimicCrimson:
                case NPCID.BigMimicHallow:
                case NPCID.Mothron:
                case NPCID.SandElemental:
                case NPCID.DD2Betsy:
                case NPCID.DD2DarkMageT1:
                case NPCID.DD2DarkMageT3:
                case NPCID.DD2OgreT2:
                case NPCID.DD2OgreT3:
                case NPCID.TargetDummy:
                    npc.buffImmune[ModContent.BuffType<Frozen>()] = true;
                    npc.buffImmune[ModContent.BuffType<HoneySlow>()] = true;
                    break;

                default:
                    if (npc.boss)
                    {
                        goto case NPCID.TargetDummy;
                    }
                    break;
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (gouge)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 60;
                damage = 10;
            }

            if (honeySlow)
            {
                npc.velocity.X *= 0.75f;
                npc.velocity.Y += !npc.noTileCollide ? 0.10f : 0.01f;
            }

            if (frozen)
            {
                npc.position = npc.oldPosition;
                npc.frameCounter = 0;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if ((npc.type == NPCID.BloodZombie || npc.type == NPCID.Drippler) && npc.value > 0f && Main.rand.NextBool(20))
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<HemoClicker>(), 1, prefixGiven: -1);
            }

            if (npc.type == NPCID.DarkCaster && npc.value > 0f && Main.rand.NextBool(20))
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<SlickClicker>(), 1, prefixGiven: -1);
            }

            if (npc.type == NPCID.PirateCaptain && npc.value > 0f && Main.rand.NextBool(20))
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<CaptainsClicker>(), 1, prefixGiven: -1);
            }

            if (npc.type == NPCID.Pumpking && npc.value > 0f && Main.rand.NextBool(10))
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<WitchClicker>(), 1, prefixGiven: -1);
            }

            if (npc.type == NPCID.IceQueen && npc.value > 0f && Main.rand.NextBool(10))
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<FrozenClicker>(), 1, prefixGiven: -1);
            }

            if (npc.type == NPCID.MartianSaucerCore && npc.value > 0f && Main.rand.NextBool(20))
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<HighTechClicker>(), 1, prefixGiven: -1);
            }

            if (!Main.expertMode && npc.type == NPCID.MoonLordCore)
            {
                Item.NewItem(npc.Hitbox, ModContent.ItemType<TheClicker>(), 1, prefixGiven: -1);
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Merchant:
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Cookie>());
                    break;

                case NPCID.TravellingMerchant:
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Soda>());
                    break;

                case NPCID.Mechanic:
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<HandCream>());
                    break;

                case NPCID.GoblinTinkerer:
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<HandCream>());
                    break;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (gouge)
            {
                if (!Main.rand.NextBool(4))
                {
                    Dust dust = Dust.NewDustDirect(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 5, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 2.2f);
                    dust.noGravity = true;
                    dust.velocity *= 1.2f;
                    dust.velocity.Y -= 0.7f;

                    Dust dust2 = Dust.NewDustDirect(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 54, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1.6f);
                    dust2.noGravity = true;
                    dust2.velocity *= 1.2f;
                    dust2.velocity.Y -= 0.7f;

                    if (Main.rand.NextBool(4))
                    {
                        dust.noGravity = false;
                        dust.scale *= 0.3f;

                        dust2.noGravity = false;
                        dust2.scale *= 0.3f;
                    }
                }
                drawColor.G = (byte)(drawColor.G * 0.35f);
                drawColor.B = (byte)(drawColor.B * 0.15f);
            }

            if (honeySlow)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 153, 0f, Main.rand.NextFloat(0.25f, 0.75f), 50, default, 1.35f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].fadeIn = 1.1f;

                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }

            if (frozen)
            {
                if (!Main.rand.NextBool(5))
                {
                    Dust dust = Dust.NewDustDirect(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 111, 0f, 0f, 0, default, 0.75f);
                    dust.noGravity = true;
                    dust.velocity *= 0f;
                    dust.fadeIn = 1.75f;
                }

                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.6f);
                drawColor.R = (byte)(drawColor.R * 0.35f);
                drawColor.G = (byte)(drawColor.G * 0.65f);
            }

            if (embrittle)
            {
                if (!Main.rand.NextBool(5))
                {
                    Dust dust = Dust.NewDustDirect(npc.position - new Vector2(2f, 2f), npc.width, npc.height, 57, 0f, 0f, 255, default, 0.65f);
                    dust.shader = GameShaders.Armor.GetSecondaryShader(20, Main.LocalPlayer);
                    dust.noGravity = true;
                    dust.velocity *= 0f;
                    dust.fadeIn = 1.75f;
                }

                drawColor.R = (byte)(drawColor.R * 1f);
                drawColor.G = (byte)(drawColor.G * 1f);
                drawColor.B = (byte)(drawColor.B * 1f);
            }
        }
    }
}