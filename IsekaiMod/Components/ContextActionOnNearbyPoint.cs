using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.View;
using UnityEngine;

namespace IsekaiMod.Components {

    [TypeId("bc1d7430da024608b6e623c70b380dff")]
    public class ContextActionOnNearbyPoint : ContextAction {
        public ActionList Actions;

        public override string GetCaption() {
            return "Run a context action nearby target point";
        }

        public override string GetDescription() {
            return "Point nearby will be action target";
        }

        public override void RunAction() {
            int actionNumber = Actions.Actions.Length;
            Vector3 point = Context.MainTarget.Point;
            point = ObstacleAnalyzer.GetNearestNode(point, null).position;
            FreePlaceSelector.PlaceSpawnPlaces(actionNumber, 1, point);
            for (int i = 0; i < actionNumber; i++) {
                point = FreePlaceSelector.GetRelaxedPosition(i, true);
                using (Context.GetDataScope(point)) {
                    Actions.Actions[i].RunAction();
                }
            }
        }
    }
}