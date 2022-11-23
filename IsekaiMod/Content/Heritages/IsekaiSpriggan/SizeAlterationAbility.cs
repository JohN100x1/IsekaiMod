using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;

namespace IsekaiMod.Content.Heritages.IsekaiSpriggan
{
    internal class SizeAlterationAbility
    {
        public static void Add()
        {
            // Spriggan Heritage
            var Icon_Spriggan = AssetLoader.LoadInternal("Heritages", "ICON_SPRIGGAN.png");
            var SizeAlterationBuff = Helpers.CreateBuff("SizeAlterationBuff", bp => {
                bp.SetName("Size Alteration");
                bp.SetDescription("This creature's size is increased by two size categories and they gain +10 Speed, +12 Strength, -2 Dexterity, +6 Constitution, and a -2 penalty to AC.");
                bp.m_Icon = Icon_Spriggan;
                bp.AddComponent<ChangeUnitSize>(c => {
                    c.m_Type = ChangeUnitSize.ChangeType.Delta;
                    c.SizeDelta = 2;
                    c.Size = Size.Fine;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Strength;
                    c.Value = 12;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Dexterity;
                    c.Value = -2;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Constitution;
                    c.Value = 6;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AC;
                    c.Value = -2;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var SizeAlterationAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("SizeAlterationAbility", bp => {
                bp.SetName("Size Alteration");
                bp.SetDescription("As a standard action, increase your size by two size categories and gain +10 Speed, +12 Strength, -2 Dexterity, +6 Constitution, and a -2 penalty to AC.");
                bp.m_Icon = Icon_Spriggan;
                bp.m_Buff = SizeAlterationBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.WithUnitCommand;
                bp.m_ActivateWithUnitCommand = UnitCommand.CommandType.Standard;
            });
        }
    }
}
