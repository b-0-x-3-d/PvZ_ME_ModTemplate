using System;
using System.Runtime.InteropServices;
using Engine;
using Projectiles;
using PVZMECSMainCore;
using Zombies;


public static class Main
{
    public unsafe static void ModInit()
    {


        PlantDefinitions.AddDefinition(new PlantDefinition(new SM_SeedType("NEW_PLANT", 49 + 0), (Image**)0,
             ReanimationType.REANIM_PLANTERN, 5, 100, 3000, PlantDefinition.PlantSubClass.SUBCLASS_SHOOTER, 100,
             (byte*)Marshal.StringToHGlobalAnsi("Gold Bloom ")));
        PlantDefinitions.AddDefinition(new PlantDefinition(new SM_SeedType("NEW_PLANT2", 49 + 0), (Image**)0,
             ReanimationType.REANIM_PEASHOOTER, 5, 450, 750, PlantDefinition.PlantSubClass.SUBCLASS_SHOOTER, 600,
             (byte*)Marshal.StringToHGlobalAnsi("Snipea ")));


    }
}

namespace Plants
{

    public class NEW_PLANT_Plant : BasePlantMod
    {
        public unsafe static bool OverrideFire(PlantPointer thisPlant, Zombie* theZombiePointer, int theRow, int weaponType)
        {

            thisPlant._ptr->mGameObject.mApp.PlayFoley(FoleyType.FOLEY_THROW);
            float aShootAngleX = (float)System.Math.Cos(Engine.Math.DEG_TO_RAD(30.0f)) * 3.33f;
            float aShootAngleY = (float)System.Math.Sin(Engine.Math.DEG_TO_RAD(30.0f)) * 3.33f;
            for (int i = 0; i < 5; i++)
            {
                thisPlant._ptr->mGameObject.mBoard.AddCoin(thisPlant._ptr->mGameObject.mX, thisPlant._ptr->mGameObject.mY, CoinType.COIN_LARGESUN, CoinMotion.COIN_MOTION_FROM_PLANT);
                
                Projectile* aProjectile = thisPlant._ptr->mGameObject.mBoard.AddProjectile(thisPlant._ptr->mGameObject.mX + 25, thisPlant._ptr->mGameObject.mY + 25, thisPlant._ptr->mGameObject.mRenderOrder - 1, thisPlant._ptr->mGameObject.mRow, ProjectileType.PROJECTILE_WINTERMELON)._ptr;
                aProjectile->mDamageRangeFlags = thisPlant.GetDamageRangeFlags(0);
                aProjectile->mMotionType = ProjectileMotion.MOTION_STAR;
                aProjectile->mVelX = 3.33f;
                aProjectile->mVelY = (float)i-2f;
            }
            thisPlant._ptr->mSquished = 1;
            return true;
        }
    }
    public class NEW_PLANT2_Plant : BasePlantMod
    {
        public unsafe static bool OverrideFire(PlantPointer thisPlant, Zombie* theZombiePointer, int theRow, int weaponType)
        {

            thisPlant._ptr->mGameObject.mApp.PlayFoley(FoleyType.FOLEY_EXPLOSION);
            float aShootAngleX = (float)System.Math.Cos(Engine.Math.DEG_TO_RAD(30.0f)) * 3.33f;
            float aShootAngleY = (float)System.Math.Sin(Engine.Math.DEG_TO_RAD(30.0f)) * 3.33f;
            for (int i = 0; i < 20; i++)
            {
                Projectile* aProjectile = thisPlant._ptr->mGameObject.mBoard.AddProjectile(thisPlant._ptr->mGameObject.mX + 25, thisPlant._ptr->mGameObject.mY + 25, thisPlant._ptr->mGameObject.mRenderOrder - 1, thisPlant._ptr->mGameObject.mRow, ProjectileType.PROJECTILE_PEA)._ptr;
                aProjectile->mDamageRangeFlags = thisPlant.GetDamageRangeFlags(0);
                aProjectile->mMotionType = ProjectileMotion.MOTION_STAR;
                aProjectile->mVelX = 6.66f;
                aProjectile->mVelY = 0.00f;
            }
            return true;
        }
    }
}