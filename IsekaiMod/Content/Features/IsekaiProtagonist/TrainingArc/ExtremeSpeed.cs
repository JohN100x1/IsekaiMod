using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.TrainingArc
{
    class ExtremeSpeed
    {
        public static void Add()
        {
            var Icon_SupersonicSpeed = Resources.GetBlueprint<BlueprintFeature>("505456aa17dd18a4e8bd8172811a4fdc").m_Icon;
            var ExtremeSpeed = Helpers.CreateBlueprint<BlueprintFeature>("ExtremeSpeed", bp => {
                bp.SetName("Extreme Speed");
                bp.SetDescription("After extensive speed training, you gain a +100 insight {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g}.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Insight;
                    c.Stat = StatType.Speed;
                    c.Value = 100;
                });
                bp.m_Icon = Icon_SupersonicSpeed;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
