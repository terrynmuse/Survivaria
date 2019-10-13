﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Corruption;
using Survivaria.Items.Food.BiomeSpecific.Crimson;
using Survivaria.Items.Food.BiomeSpecific.Desert;
using Survivaria.Items.Food.BiomeSpecific.Hallow;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Materials;
using Survivaria.Tiles.Plants;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Survivaria
{
    public class SurvivariaGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type) //Thanks antiaris for this
        {
            if (Main.netMode != 1 && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.Grass)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Guavado>(), Main.rand.Next(1, 2));
                }
                if (type == TileID.Cactus && Main.tile[i, j + 1].type == TileID.Sand)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Date>(), 1);
                }
                if (type == TileID.Sand && Main.tile[i, j - 1].type == TileID.Cactus)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Date>(), 1);
                }
                if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.Mud || Main.tile[i, j + 1].type == TileID.JungleGrass))
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<DragonFruit>(), Main.rand.Next(1, 2));
                }
                if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.CorruptGrass))
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<PutridOlives>(), Main.rand.Next(1, 2));
                }
                if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.FleshGrass))
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Greneyede>(), Main.rand.Next(1, 2));
                }
                if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.HallowedGrass))
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<RockCandy>(), Main.rand.Next(1, 2));
                }
                if ((Main.tile[i, j].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2) && type != TileID.Trees && type != TileID.MushroomPlants && type != 0)
                {
                    if (Main.rand.Next(5) == 0)
                        Item.NewItem(i * 16, (j) * 16, 20, 30, mod.ItemType<BlossomWheat>(), 1);
                }
            }
            return base.Drop(i, j, type);
        }
        public override void RandomUpdate(int i, int j, int type)
        {
            if ((Main.tile[i, j].type == TileID.Grass && (Main.tile[i, j - 1].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2 || Main.tile[i, j - 1].type < 0)) && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 2, mod.TileType<PeppermintPlant>(), true, true);
                    //Main.NewText("Plant placed at: " + new Vector2(i, j));
                }
            }
            if ((Main.tile[i, j].type == TileID.JungleGrass && (Main.tile[i, j - 1].type == TileID.JunglePlants || Main.tile[i, j - 1].type == TileID.JunglePlants2 || Main.tile[i, j - 1].type < 0)) && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 3, mod.TileType<CorneyPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.JungleGrass && (Main.tile[i, j + 1].type == TileID.JunglePlants || Main.tile[i, j + 1].type == TileID.JunglePlants2 || Main.tile[i, j + 1].type == TileID.JungleVines || Main.tile[i, j + 1].type < 0) && Main.tile[i, j].slope() == 0)
            {
                if (Main.rand.Next(30) == 0)
                {
                    WorldGen.PlaceTile(i, j + 1, mod.TileType<EnigmaticRootPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.MushroomGrass && (Main.tile[i, j - 1].type == TileID.MushroomPlants || Main.tile[i, j - 1].type < 0) && Main.tile[i, j].slope() == 0))
            {
                if (Main.rand.Next(25) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<MushyCarrotPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.CorruptGrass && (Main.tile[i, j - 1].type == TileID.CorruptPlants || Main.tile[i, j - 1].type < 0) && Main.tile[i, j].slope() == 0 && !Main.dayTime))
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<CursedEggplantPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.FleshGrass && (Main.tile[i, j - 1].type == TileID.FleshWeeds || Main.tile[i, j - 1].type < 0) && Main.tile[i, j].slope() == 0 && !Main.dayTime))
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<BleedRootPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.SnowBlock && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<PearlBerryPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.Grass && (Main.tile[i, j - 1].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2 || Main.tile[i, j - 1].type < 0)) && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<ReecePlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.HallowedGrass && (Main.tile[i, j - 1].type == TileID.HallowedPlants || Main.tile[i, j - 1].type == TileID.HallowedPlants2 || Main.tile[i, j - 1].type < 0)) && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 2, mod.TileType<SparklingBerryPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Sand && !Main.tile[i, j - 1].active() && Main.tile[i, j - 1].liquid > 0 && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    WorldGen.PlaceTile(i, j - 3, mod.TileType<AmalgaePlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Cactus && Main.tile[i, j].frameY == 0 && Main.tile[i, j - 1].type < 0 && Main.dayTime)
            {
                if (Main.rand.Next(50) == 0)
                {
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            WorldGen.PlaceTile(i, j - 1, mod.TileType<PricklyPearOrangePlant>(), true, true);
                            break;
                        case 1:
                            WorldGen.PlaceTile(i, j - 1, mod.TileType<PricklyPearMagentaPlant>(), true, true);
                            break;
                        case 2:
                            WorldGen.PlaceTile(i, j - 1, mod.TileType<PricklyPearRedPlant>(), true, true);
                            break;
                        case 3:
                            WorldGen.PlaceTile(i, j - 1, mod.TileType<PricklyPearWhitePlant>(), true, true);
                            break;
                        case 4:
                            WorldGen.PlaceTile(i, j - 1, mod.TileType<PricklyPearYellowPlant>(), true, true);
                            break;
                    }
                }
            }
            base.RandomUpdate(i, j, type);
        }
    }
}
