using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    //need turn counter

    //need 2 ques for each players orders

    //need to pop off of each queue based on coin flip

    struct TroopComands
    {

    }


    Queue<TroopComands> troopComandsP1 = new();
    Queue<TroopComands> troopComandsP2 = new();




    void turn()
    {
        for (int i = 0; i < troopComandsP1.Count + troopComandsP2.Count; i++)
        {

        }
        if (troopComandsP1.Count > 0 || troopComandsP2.Count > 0)
        { 
            if (coinflip() == 0)
            {
                quePopper(troopComandsP1);
            }
            else
            {
                quePopper(troopComandsP2);
            }
        }
        else
        {
            //increment turn
        }
    }

    void quePopper(Queue<TroopComands> currentQue)
    {
        currentQue.Dequeue();
    }

    int coinflip()
    {
        return Random.Range(0, 1);
    }
}
