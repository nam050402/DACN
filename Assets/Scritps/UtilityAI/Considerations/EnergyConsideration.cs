using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "Energy", menuName = "UtilityAI/Considerations/Energy")]
    public class EnergyConsideration : Consideration
    {
        public override float ScoreConsideration(VillageController npc)
        {
            float energy = 1 - npc.status.energy / 100f;
            float score = Mathf.Clamp01(energy*energy);
            Debug.Log("energy:" + score);
            return score;
        }
    }
}
