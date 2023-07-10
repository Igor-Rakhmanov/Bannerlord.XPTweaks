using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.TwoDimension;
using MathF = TaleWorlds.Library.MathF;

namespace Bannerlord.XPTweaks.Logic
{
    public class ModifiedSmithingModel : DefaultSmithingModel
    {
        private readonly ISettingsProvider _settingsProvider;

        public ModifiedSmithingModel(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public override float ResearchPointsNeedForNewPart(int totalPartCount, int openedPartCount)
        {
            if (!_settingsProvider.IsInitialized)
            {
                return base.ResearchPointsNeedForNewPart(totalPartCount, openedPartCount);
            }

            return base.ResearchPointsNeedForNewPart(totalPartCount, openedPartCount) * _settingsProvider.Settings.ResearchPointsNeededMultiplier;
        }

        public override Crafting.OverrideData GetModifierChanges(int modifierTier, Hero hero, WeaponComponentData weapon)
        {
            if (!_settingsProvider.IsInitialized)
            {
                return base.GetModifierChanges(modifierTier, hero, weapon);
            }

            int pointsToModify = GetPointsToModify(modifierTier);
            Crafting.OverrideData overrideData = pointsToModify != 0 ? ModifyWeaponDesign(pointsToModify, weapon) : new Crafting.OverrideData();

            if (hero.GetPerkValue(DefaultPerks.Crafting.SharpenedEdge))
            {
                overrideData.SwingDamageOverriden += MathF.Round(weapon.SwingDamage * DefaultPerks.Crafting.SharpenedEdge.PrimaryBonus * 0.01f);
            }

            if (hero.GetPerkValue(DefaultPerks.Crafting.SharpenedTip))
            {
                overrideData.ThrustDamageOverriden += MathF.Round(weapon.ThrustDamage * DefaultPerks.Crafting.SharpenedTip.PrimaryBonus * 0.01f);
            }

            return overrideData;
        }

        public override int GetModifierTierForSmithedWeapon(WeaponDesign weaponDesign, Hero hero)
        {
            if (!_settingsProvider.IsInitialized)
            {
                return base.GetModifierTierForSmithedWeapon(weaponDesign, hero);
            }

            int weaponDesignDifficulty = CalculateWeaponDesignDifficulty(weaponDesign);
            int difficultyDifference = hero.CharacterObject.GetSkillValue(DefaultSkills.Crafting) - weaponDesignDifficulty;

            if (difficultyDifference < 0 && !_settingsProvider.Settings.DisableDifficultyPenalty)
            {
                return GetPenaltyForLowSkill(difficultyDifference);
            }

            float randomFloat = MBRandom.RandomFloat;
            float legendaryChance = hero.GetPerkValue(DefaultPerks.Crafting.LegendarySmith)
                ? (DefaultPerks.Crafting.LegendarySmith.PrimaryBonus + Math.Max(0f, hero.GetSkillValue(DefaultSkills.Crafting) - 300) * 0.01f) * _settingsProvider.Settings.LegendaryWeaponChanceMultiplier
                : 0f;

            float masterworkChance = hero.GetPerkValue(DefaultPerks.Crafting.MasterSmith)
                ? DefaultPerks.Crafting.MasterSmith.PrimaryBonus * _settingsProvider.Settings.MasterworkWeaponChanceMultiplier
                : 0f;

            float fineChance = hero.GetPerkValue(DefaultPerks.Crafting.ExperiencedSmith)
                ? DefaultPerks.Crafting.ExperiencedSmith.PrimaryBonus * _settingsProvider.Settings.FineWeaponChanceMultiplier
                : 0f;

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
            if (!_settingsProvider.IsInitialized)
                return base.GetEnergyCostForRefining(ref refineFormula, hero);

            return (int)Mathf.Floor(base.GetEnergyCostForRefining(ref refineFormula, hero) * _settingsProvider.Settings.SmithingEnergyCostMultiplier);
        }

        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
        {
            if (!_settingsProvider.IsInitialized)
                return base.GetEnergyCostForSmelting(item, hero);

            return (int)Mathf.Floor(base.GetEnergyCostForSmelting(item, hero) * _settingsProvider.Settings.SmithingEnergyCostMultiplier);
        }

        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
        {
            if (!_settingsProvider.IsInitialized)
                return base.GetEnergyCostForSmithing(item, hero);

            return (int)Mathf.Floor(base.GetEnergyCostForSmithing(item, hero) * _settingsProvider.Settings.SmithingEnergyCostMultiplier);
        }

        private int GetPenaltyForLowSkill(int difference)
        {
            float randomFloat = MBRandom.RandomFloat;
            randomFloat += -0.01f * difference;

            if (randomFloat < 0.4f) return -1;
            if (randomFloat < 0.7f) return -2;
            if (randomFloat < 0.9f) return -3;
            if (randomFloat < 1f) return -4;
            return -5;
        }

        private Crafting.OverrideData ModifyWeaponDesign(int numPoints, WeaponComponentData weapon)
        {
            Crafting.OverrideData overrideData = new();
            int num = 0;
            int overridesSum = 0;
            while (overridesSum != numPoints && num++ < 500)
            {
                int num3 = numPoints > 0 ? 1 : -1;
                if (MBRandom.RandomFloat < 0.1f)
                {
                    num3 = -num3;
                }

                // Should turn into some kind of helper, because this looks like shit
                float randomFloat = MBRandom.RandomFloat;
                if (randomFloat < 0.2f && weapon.SwingDamageType is not DamageTypes.Invalid)
                {
                    overrideData.SwingSpeedOverriden += num3;
                }
                else if (randomFloat < 0.4f && weapon.SwingDamageType is not DamageTypes.Invalid)
                {
                    overrideData.SwingDamageOverriden += num3;
                }
                else if (randomFloat < 0.6f && weapon.ThrustDamageType is not DamageTypes.Invalid)
                {
                    overrideData.ThrustSpeedOverriden += num3;
                }
                else if (randomFloat < 0.8f && weapon.ThrustDamageType is not DamageTypes.Invalid)
                {
                    overrideData.ThrustDamageOverriden += num3;
                }
                else
                {
                    overrideData.Handling += num3;
                }

                overridesSum = GetOverridesSum(overrideData);
            }

            return overrideData;
        }

        private int GetPointsToModify(int modifierTier)
        {
            if (modifierTier > -4)
            {
                return modifierTier switch
                {
                    3 => _settingsProvider.Settings.LegendaryWeaponBonusPoints,
                    2 => _settingsProvider.Settings.MasterworkWeaponBonusPoints,
                    1 => _settingsProvider.Settings.FineWeaponBonusPoints,
                    0 => 0,
                    -1 => -2,
                    -2 => -4,
                    -3 => -6,
                    _ => 10,
                };
            }

            return -8;
        }

        private int GetOverridesSum(Crafting.OverrideData overrideData)
        {
            return overrideData.SwingSpeedOverriden +
                overrideData.SwingDamageOverriden +
                overrideData.ThrustSpeedOverriden +
                overrideData.ThrustDamageOverriden +
                overrideData.Handling;
        }
    }
}
