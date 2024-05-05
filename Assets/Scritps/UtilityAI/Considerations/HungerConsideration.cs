using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "Hunger", menuName = "UtilityAI/Considerations/Hunger")]
    public class HungerConsideration : Consideration
    {
        public override float ScoreConsideration(VillageController npc)
        {
            float hunger = npc.status.hunger / 100f;
            float score = Mathf.Clamp01(hunger*hunger);
            Debug.Log("hunger:" + score);
            return score;
        }
    }
}
