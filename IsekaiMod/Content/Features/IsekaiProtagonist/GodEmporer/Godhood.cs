using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmporer
{
    class Godhood
    {
        public static void Add()
        {
            var Icon_Godhood = AssetLoader.LoadInternal("Features", "ICON_GODHOOD.png");
            var Godhood = Helpers.CreateBlueprint<BlueprintFeature>("Godhood", bp => {
                bp.SetName("Godhood");
                bp.SetDescription("At 20th level, you become a god. You gain 100 spell resistance and are immune to all {g|Encyclopedia:Physical_Damage}physical damage{/g}. "
                    + "Your attack ignore concealment, critical immunity, and damage reduction. Any critical threats you make are automatically confirmed. "
                    + "The spells you cast ignore spell resistance and spell immunity.");
                bp.m_Icon = Icon_Godhood;
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = 100;
                });
                bp.AddComponent<AddPhysicalImmunity>();
                bp.AddComponent<IgnoreConcealment>();
                bp.AddComponent<IgnoreCritImmunity>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<InitiatorCritAutoconfirm>();
                bp.AddComponent<IgnoreSpellImmunity>();
                bp.AddComponent<IgnoreSpellResistanceForSpells>();
                bp.IsClassFeature = true;
            });
        }
    }
}
