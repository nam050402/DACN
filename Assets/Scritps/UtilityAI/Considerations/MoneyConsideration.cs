using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "Money", menuName = "UtilityAI/Considerations/Money")]
    public class MoneyConsideration : Consideration
    {
        public override float ScoreConsideration(VillageController npc)
        {
            int moneyAccpetable = 20; 
            float score = Mathf.Clamp01(1f-(npc.status.money*1f/(npc.status.money + 3*moneyAccpetable)));
            Debug.Log("money:" + score);
            return score;
        }
    }
}
