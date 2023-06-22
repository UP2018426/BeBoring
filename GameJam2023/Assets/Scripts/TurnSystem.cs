using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class TurnSystem : MonoBehaviour
{
    //need turn counter

    //need 2 ques for each players orders

    //need to pop off of each queue based on coin flip


    public GameManager gm;

    Queue<TroopCommands> troopComandsP1 = new();
    Queue<TroopCommands> troopComandsP2 = new();



    void SetQueue(List<TroopCommands> commandsp1, List<TroopCommands> commandsp2)
    {
        Debug.Log("setQue");

        for (int i = 0; i < commandsp1.Count; i++)
        {
            Debug.Log("setQue1");
            troopComandsP1.Enqueue(commandsp1[i]);

        }
        for (int i = 0; i < commandsp2.Count; i++)
        {
            Debug.Log("setQue2");
            troopComandsP2.Enqueue(commandsp2[i]);
        }
    }


    public void turn()
    {
        gm.SetMapState();

        SetQueue(gm.playerAMoves, gm.playerBMoves);

        for (int i = 0; i < troopComandsP1.Count; i++)
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
        gm.playerAMoves.Clear();
        
        //ADD THING FOR ATTACKS

        gm.GetMapState();
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
        Debug.Log("run comand");
        if (command.moveType == MoveType.Move)
        {
            command.gamObj.transform.position = command.targetPos;
        }
    }
}
