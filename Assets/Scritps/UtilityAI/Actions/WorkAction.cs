using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Work", menuName = "UtilityAI/Actions/Work")]
    public class WorkAction : Action
    {
        public override void Execute(VillageController npc)
        {
            npc.DoWork(3);
            Debug.Log("work again");
        }
        public override void SetRequiredDestination(VillageController npc)
        {
            RequiredDestination = npc.workPlace;
        }
    }
}
