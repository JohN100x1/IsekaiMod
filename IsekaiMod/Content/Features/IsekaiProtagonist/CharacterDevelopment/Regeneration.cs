using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Components;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class Regeneration
    {
        public static void Add()
        {
            var Icon_Regeneration = AssetLoader.LoadInternal("Features", "ICON_REGENERATION.png");
            var RegenerationFeature = Helpers.CreateFeature("RegenerationFeature", bp => {
                bp.SetName("Regeneration");
                bp.SetDescription("You regain 10 hit points per round and cannot die while regeneration is functioning. "
                    + "Regeneration is disabled for 1 round when you are hit with an acid or fire attack. ");
                bp.m_Icon = Icon_Regeneration;
                bp.AddComponent<AddEffectRegeneration>(c => {
                    c.Heal = 10;
                    c.Unremovable = false;
                    c.CancelByMagicWeapon = false;
                    c.CancelDamageEnergyTypes = new DamageEnergyType[] { DamageEnergyType.Acid, DamageEnergyType.Fire };
                    c.CancelDamageAlignmentTypes = new DamageAlignment[0];
                    c.CancelDamageMaterials = new PhysicalDamageMaterial[0];
                });
                bp.AddComponent<PrerequisiteCharacterLevel>(c => {
                    c.Level = 10;
                });
            });

            CharacterDevelopmentSelection.AddToSelection(RegenerationFeature);
        }
    }
}
