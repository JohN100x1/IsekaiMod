using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.UnitLogic.Buffs.Components;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherFastHealing
    {
        public static void Add()
        {
            var DeathsnatcherFastHealing = Helpers.CreateFeature("DeathsnatcherFastHealing", bp => {
                bp.SetName("Fast Healing 10");
                bp.SetDescription("A creature with the fast healing special ability regains hit points at an exceptional rate. "
                    + "Fast healing continues to function even if the creature is unconscious or has less than zero hit points, as long as it's alive. "
                    + "If the creature dies, the effects of fast healing end immediately.");
                bp.AddComponent<AddEffectFastHealing>(c => {
                    c.Heal = 10;
                    c.Bonus = 0;
                });
            });
        }
    }
}
