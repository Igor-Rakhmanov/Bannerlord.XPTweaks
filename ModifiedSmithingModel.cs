using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using System;
using Bannerlord.XPTweaks.Settings;
using TaleWorlds.TwoDimension;

namespace Bannerlord.XPTweaks
{
    internal class ModifiedSmithingModel : DefaultSmithingModel
    {
        public override float ResearchPointsNeedForNewPart(int totalPartCount, int openedPartCount)
        {
            var defaultResult = base.ResearchPointsNeedForNewPart(totalPartCount, openedPartCount);

            if (MCMSettings.Instance is null) return defaultResult;

            return defaultResult * MCMSettings.Instance.ResearchPointsNeededMultiplier;
        }

        public override Crafting.OverrideData GetModifierChanges(int modifierTier, Hero hero, WeaponComponentData weapon)
        {
            int pointsToModify = GetPointsToModify(modifierTier);
            Crafting.OverrideData overrideData = ((pointsToModify != 0) ? ModifyWeaponDesign(pointsToModify) : new Crafting.OverrideData());
            if (hero.GetPerkValue(DefaultPerks.Crafting.SharpenedEdge))
            {
                overrideData.SwingDamageOverriden += MathF.Round((float)weapon.SwingDamage * DefaultPerks.Crafting.SharpenedEdge.PrimaryBonus * 0.01f);
            }

            if (hero.GetPerkValue(DefaultPerks.Crafting.SharpenedTip))
            {
                overrideData.ThrustDamageOverriden += MathF.Round((float)weapon.ThrustDamage * DefaultPerks.Crafting.SharpenedTip.PrimaryBonus * 0.01f);
            }

            return overrideData;
        }

        public override int GetModifierTierForSmithedWeapon(WeaponDesign weaponDesign, Hero hero)
        {
            if (MCMSettings.Instance is null) return base.GetModifierTierForSmithedWeapon(weaponDesign, hero);

            int weaponDesignDifficulty = CalculateWeaponDesignDifficulty(weaponDesign);
            int difficultyDifference = hero.CharacterObject.GetSkillValue(DefaultSkills.Crafting) - weaponDesignDifficulty;
            if (difficultyDifference < 0 && !MCMSettings.Instance.DisableDifficultyPenalty)
            {
                return GetPenaltyForLowSkill(difficultyDifference);
            }

            float randomFloat = MBRandom.RandomFloat;
            float legendaryChance = (hero.GetPerkValue(DefaultPerks.Crafting.LegendarySmith) 
                ? (DefaultPerks.Crafting.LegendarySmith.PrimaryBonus + 
                    Math.Max(0f, hero.GetSkillValue(DefaultSkills.Crafting) - 300) * 0.01f) * MCMSettings.Instance.LegendaryWeaponChanceMultiplier
                : 0f);

            float masterworkChance = (hero.GetPerkValue(DefaultPerks.Crafting.MasterSmith) 
                ? DefaultPerks.Crafting.MasterSmith.PrimaryBonus * MCMSettings.Instance.MasterworkWeaponChanceMultiplier
                : 0f);

            float fineChance = (hero.GetPerkValue(DefaultPerks.Crafting.ExperiencedSmith) 
                ? DefaultPerks.Crafting.ExperiencedSmith.PrimaryBonus * MCMSettings.Instance.FineWeaponChanceMultiplier
                : 0f);
            
            if (randomFloat < legendaryChance)
            {
                return 3;
            }

            if (randomFloat < legendaryChance + masterworkChance)
            {
                return 2;
            }

            if (randomFloat < legendaryChance + masterworkChance + fineChance)
            {
                return 1;
            }

            return 0;
        }

        public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero)
        {
            if (MCMSettings.Instance is null)
                return base.GetEnergyCostForRefining(ref refineFormula, hero);

            return (int) Mathf.Floor(base.GetEnergyCostForRefining(ref refineFormula, hero) * MCMSettings.Instance.SmithingEnergyCostMultiplier);
        }

        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
        {
            if (MCMSettings.Instance is null)
                return base.GetEnergyCostForSmelting(item, hero);

            return (int)Mathf.Floor(base.GetEnergyCostForSmelting(item, hero) * MCMSettings.Instance.SmithingEnergyCostMultiplier);
        }

        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
        {
            if (MCMSettings.Instance is null)
                return base.GetEnergyCostForSmithing(item, hero);

            return (int)Mathf.Floor(base.GetEnergyCostForSmithing(item, hero) * MCMSettings.Instance.SmithingEnergyCostMultiplier);
        }

        private int GetPenaltyForLowSkill(int difference)
        {
            float randomFloat = MBRandom.RandomFloat;
            randomFloat += -0.01f * (float)difference;
            if (!(randomFloat < 0.4f))
            {
                if (!(randomFloat < 0.7f))
                {
                    if (!(randomFloat < 0.9f))
                    {
                        if (!(randomFloat < 1f))
                        {
                            return -5;
                        }

                        return -4;
                    }

                    return -3;
                }

                return -2;
            }

            return -1;
        }

        private Crafting.OverrideData ModifyWeaponDesign(int numPoints)
        {
            Crafting.OverrideData overrideData = new Crafting.OverrideData();
            int num = 0;
            int num2 = 0;
            while (num2 != numPoints && num < 500)
            {
                int num3 = ((numPoints > 0) ? 1 : (-1));
                if (MBRandom.RandomFloat < 0.1f)
                {
                    num3 = -num3;
                }

                // TODO: values for swing or thrust should not increase if corresponding damage type is invalid (this is what TW overlooked)
                float randomFloat = MBRandom.RandomFloat;
                if (randomFloat < 0.2f)
                {
                    overrideData.SwingSpeedOverriden += num3;
                }
                else if (randomFloat < 0.4f)
                {
                    overrideData.SwingDamageOverriden += num3;
                }
                else if (randomFloat < 0.6f)
                {
                    overrideData.ThrustSpeedOverriden += num3;
                }
                else if (randomFloat < 0.8f)
                {
                    overrideData.ThrustDamageOverriden += num3;
                }
                else
                {
                    overrideData.Handling += num3;
                }

                num++;
                num2 = overrideData.SwingSpeedOverriden + overrideData.SwingDamageOverriden + overrideData.ThrustSpeedOverriden + overrideData.ThrustDamageOverriden + overrideData.Handling;
            }

            return overrideData;
        }

        private int GetPointsToModify(int modifierTier)
        {
            if (modifierTier > -4)
            {
                return modifierTier switch
                {
                    3 => MCMSettings.Instance?.LegendaryWeaponBonusPoints ?? 10,
                    2 => MCMSettings.Instance?.MasterworkWeaponBonusPoints ?? 5,
                    1 => MCMSettings.Instance?.FineWeaponBonusPoints ?? 2,
                    0 => 0,
                    -1 => -2,
                    -2 => -4,
                    -3 => -6,
                    _ => 10,
                };
            }

            return -8;
        }
    }
}
