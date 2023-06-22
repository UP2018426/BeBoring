using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class TurnSystem : MonoBehaviour
{
    //need turn counter

    //need 2 ques for each players orders

    //need to pop off of each queue based on coin flip


    Queue<TroopCommands> troopComandsP1 = new();
    Queue<TroopCommands> troopComandsP2 = new();




    void turn()
    {
        for (int i = 0; i < troopComandsP1.Count-1 + troopComandsP2.Count-1; i++)
        {
            if (troopComandsP1.Count + troopComandsP2.Count == 0)
            {
                return;
            }
            if (troopComandsP1.Count > 0 && troopComandsP2.Count > 0)
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
            else if(troopComandsP1.Count == 0)
            {
                    quePopper(troopComandsP2);
            }
            else if(troopComandsP2.Count == 0)
            {
                    quePopper(troopComandsP1);
            }
        }
    }

    void quePopper(Queue<TroopCommands> currentQue)
    {
        RunCommands(currentQue.Dequeue());
    }

    int coinflip()
    {
        return Random.Range(0, 1);
    }


    void RunCommands(TroopCommands command)
    {

    }
}
