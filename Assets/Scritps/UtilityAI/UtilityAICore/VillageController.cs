using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

public enum State
{
    Decide,
    Move,
    Execute
}
public class VillageController : MonoBehaviour
{
    public AIBrain aiBrain { get; set; }
    public Status status { get; set; }
    public MoveController mover { get; set; }
    private State state { get; set; }
    [SerializeField] public Transform restPlace;
    [SerializeField] public Transform foodShop;
    [SerializeField] public Transform workPlace;
    private void Start()
    {
        aiBrain = GetComponent<AIBrain>();
        status = GetComponent<Status>();
        mover = GetComponent<MoveController>();
    }
    private void Update()
    {
        /*if (aiBrain.finishedDeciding)
        {
            aiBrain.finishedDeciding = false;
            aiBrain.bestAction.Execute(this);
        }*/
        status.UpdateEnergy();
        status.UpdateHunger();
        FSMTick();
    }
    public void FSMTick()
    {
        if (state == State.Decide)
        {
            aiBrain.DecideBestAction();

            if (Vector3.Distance(aiBrain.bestAction.RequiredDestination.position, this.transform.position) < 1f)
            {
                state = State.Execute;
            }
            else
            {
                state = State.Move;
            }
        } else if (state == State.Move)
        {
            float distance = Vector3.Distance(aiBrain.bestAction.RequiredDestination.position, this.transform.position);
            if (distance < 2f)
            {
                state = State.Execute;
            }
            else
            {
                Debug.Log("Still moving!");
                mover.MoveTo(aiBrain.bestAction.RequiredDestination.position);
            }
        } else if (state == State.Execute) 
        {
            if (aiBrain.finishedExecutingBestAction == false)
            {
                if (aiBrain.canStartExecutingBestAction == true)
                {
                    Debug.Log("Executing action");
                    aiBrain.bestAction.Execute(this);
                    aiBrain.canStartExecutingBestAction = false;
                }
                else
                    Debug.Log("Currently working");
            }
            else if (aiBrain.finishedExecutingBestAction == true)
            {
                Debug.Log("Exit execute state");
                state = State.Decide;
            } 
        }
    }
    public void OnFinishedAction()
    {
        aiBrain.DecideBestAction();
    }

    #region Coroutine
    public void DoWork(int time)
    {
        StartCoroutine(WorkCoroutine(time));
    }
    IEnumerator WorkCoroutine(int time)
    {
        int counter = time;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        Debug.Log("I just harvested 1 resource!");
        status.money += 10;

        //OnFinishedAction();
        aiBrain.finishedExecutingBestAction = true;
        aiBrain.canStartExecutingBestAction = true;
        yield break;
    }
    public void DoRest(int time)
    {
        StartCoroutine(RestCoroutine(time));
    }
    IEnumerator RestCoroutine(int time)
    {
        int counter = time;
        while (counter > 0)
        {
            yield return new WaitForSeconds(2);
            counter--;
        }

        Debug.Log("I rested and gained 20 energy!");
        status.energy += 20;

        //OnFinishedAction();
        aiBrain.finishedExecutingBestAction = true;
        aiBrain.canStartExecutingBestAction = true;
        yield break;
    }
    public void DoEat(int time)
    {
        StartCoroutine(EatCoroutine(time));
    }
    IEnumerator EatCoroutine(int time)
    {
        int counter = time;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        Debug.Log("I ate food!");
        status.hunger -= 30;
        status.money -= 10;

        aiBrain.finishedExecutingBestAction = true;
        aiBrain.canStartExecutingBestAction = true;
        yield break;
    }

    #endregion
}
