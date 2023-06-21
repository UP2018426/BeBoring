using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    internal static GameManager instance;
    public GameObject selectedUnit;

    public List<TroopCommands> playerAMoves = new List<TroopCommands>();
    public List<Vector3> allTroops = new List<Vector3>();

    public enum MoveType
    {
        Move,
        Attack,
        ToMarchForm,
        ToDefenceForm,
        ToAttackForm
    }
    public struct TroopCommands 
    {
        MoveType moveType;
        Vector2 pos;
        public TroopCommands(MoveType moveType, Vector2 pos)
        {
            this.moveType = moveType;
            this.pos = pos;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerAMoves.Count);
        GetMapState();
    }

    void GetMapState()
    {
        allTroops.Clear();
        var temp = GameObject.FindGameObjectsWithTag("Unit");
        
        for (int i = 0; i < /*GameObject.FindGameObjectsWithTag("Unit")*/temp.Length; i++)
        {
            allTroops.Add(/*GameObject.FindGameObjectsWithTag("Unit")*/temp[i].transform.position);
        }
    }
    
}
