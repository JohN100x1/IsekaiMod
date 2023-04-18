using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class InfiniteSpace {

        public static void Add() {
            var Icon_InfiniteSpace = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_INFINITE_SPACE.png");
            var InfiniteSpaceFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "InfiniteSpaceFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Infinite Space");
                bp.SetDescription(IsekaiContext, "\"Hey you, yes you! Have you ever wondered why the bag of holding is so limited? I mean, you can't even fit your whole harem inside. "
                    + "Well, with the Interdimensional Pocket 9000 now you can! Using advanced Numerian technologies with state-of-the-art Alkenstarian manufacturing techniques, "
                    + "the Interdimensional Pocket 9000 is able to have a storage capacity of INFINITE tons."
                    + "\nAnd that's not all! The composite nahyndrian crystal and dragonhide nanofibers provide an excellent, sleek, and tough exterior, ensuring that it is both "
                    + "comfortable to use and durable even in the harshest environments."
                    + "\nSo what are you waiting for? Get your Interdimensional Pocket 9000 today and experience the ultimate in storage solutions. "
                    + "Whether you're carrying your harem, your plethora of corpse-looted weapons, or your suspiciously large amount of gold, the Interdimensional Pocket 9000 is "
                    + "the perfect accessory for all your storage needs. Don't miss out on this incredible opportunity - order now!\""
                    + "\n— Antonius Sullivarus, the Merchant Mage of Magnificent Wares"
                    + "\nBenefit: You have an infinite carry capacity.");
                bp.m_Icon = Icon_InfiniteSpace;
                bp.AddComponent<AddPartyEncumbrance>(c => {
                    c.Value = 1_000_000;
                });
            });

            OverpoweredAbilitySelection.AddToSelection(InfiniteSpaceFeature);
        }
    }
}