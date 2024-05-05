using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Rest", menuName = "UtilityAI/Actions/Rest")]
    public class RestAction : Action
    {
        public override void Execute(VillageController npc)
        {
            npc.DoRest(3);
        }
        public override void SetRequiredDestination(VillageController npc)
        {
            RequiredDestination = npc.restPlace;
        }
    }
}
