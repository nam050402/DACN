using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/Actions/Eat")]
    public class EatAction : Action
    {
        public override void Execute(VillageController npc)
        {
            npc.DoEat(1);
        }
        public override void SetRequiredDestination(VillageController npc)
        {
            RequiredDestination = npc.foodShop;
        }
    }
}
