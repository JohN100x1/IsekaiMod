using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class ExceptionalSummoningFeature
    {
        public static void Add()
        {
            var Icon_SuperiorSummoning = AssetLoader.LoadInternal("Features", "ICON_EXCEPTIONAL_SUMMONING.png");
            var ExceptionalSummoningSummonBuff = Helpers.CreateBlueprint<BlueprintBuff>("ExceptionalSummoningSummonBuff", bp => {
                bp.SetName("Exceptional Summon");
                bp.SetDescription("This creature gets a +100 {g|Encyclopedia:Bonus}bonus{/g} to maximum {g|Encyclopedia:HP}Hit Points{/g} and a +10 bonus to Attack, AC, and saving throws.");
                bp.m_Icon = Icon_SuperiorSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.HitPoints;
                    c.Value = 100;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.AC;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.SaveFortitude;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.SaveReflex;
                    c.Value = 10;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.SaveWill;
                    c.Value = 10;
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var ExceptionalSummoningBuff = Helpers.CreateBlueprint<BlueprintBuff>("ExceptionalSummoningBuff", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summoned creatures get a +100 {g|Encyclopedia:Bonus}bonus{/g} to maximum {g|Encyclopedia:HP}Hit Points{/g} and a +10 bonus to Attack, AC, and saving throws.");
                bp.m_Icon = Icon_SuperiorSummoning;
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var ExceptionalSummoningAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("ExceptionalSummoningAbility", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summoned creatures get a +100 {g|Encyclopedia:Bonus}bonus{/g} to maximum {g|Encyclopedia:HP}Hit Points{/g} and a +10 bonus to Attack, AC, and saving throws.");
                bp.m_Icon = Icon_SuperiorSummoning;
                bp.m_Buff = ExceptionalSummoningBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var ExceptionalSummoningFeature = Helpers.CreateBlueprint<BlueprintFeature>("ExceptionalSummoningFeature", bp => {
                bp.SetName("Exceptional Summoning");
                bp.SetDescription("Your summoned creatures get a +100 {g|Encyclopedia:Bonus}bonus{/g} to maximum {g|Encyclopedia:HP}Hit Points{/g} and a +10 bonus to Attack, AC, and saving throws.");
                bp.m_Icon = Icon_SuperiorSummoning;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ExceptionalSummoningAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });
            ExceptionalSummoningBuff.AddComponent<OnSpawnBuff>(c => {
                c.m_IfHaveFact = ExceptionalSummoningFeature.ToReference<BlueprintFeatureReference>();
                c.m_buff = ExceptionalSummoningSummonBuff.ToReference<BlueprintBuffReference>();
                c.CheckDescriptor = true;
                c.SpellDescriptor = SpellDescriptor.Summoning;
                c.IsInfinity = true;
            });
        }
    }
}
