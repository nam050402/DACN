using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UtilityAI

{
    public class AIBrain : MonoBehaviour
    {
        public bool finishedDeciding { get; set; }
        public bool canStartExecutingBestAction { get; set; }
        public bool finishedExecutingBestAction { get; set; }
        public Action bestAction { get; set; }
        [SerializeField] private VillageController npc;
        [SerializeField] private Text board;
        [SerializeField] private Action[] actionAvailable;


        // Start is called before the first frame update
        void Start()
        {
            //npc.GetComponent<VillageController>();
            finishedDeciding = false;
            finishedExecutingBestAction = false;
            canStartExecutingBestAction = true;
    }

        // Update is called once per frame
        void Update()
        {
            /*if (bestAction is null)
            {
                DecideBestAction(actionAvailable);
            }*/
        }

        public void DecideBestAction()
        {
            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i = 0; i < actionAvailable.Length; i++)
            {
                if (ScoreAction(actionAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionAvailable[i].score;
                }
            }

            bestAction = actionAvailable[nextBestActionIndex];
            Debug.Log("Action is decided");
            bestAction.SetRequiredDestination(npc);
            finishedDeciding = true;
            finishedExecutingBestAction = false;
            board.text = "Action: " + bestAction.Name;
        }

        public float ScoreAction(Action action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration(npc);
                score *= considerationScore;

                if (score == 0)
                {
                    action.score = 0;
                    return action.score;
                }
            }

            float originalScore = score;
            float modFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;
        }


    }
}
