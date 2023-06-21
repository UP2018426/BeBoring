using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/Unit", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    [SerializeField] internal string unitName;

    [SerializeField] private int numberOfMoves;
    
    [SerializeField] internal int unitCount;

    [SerializeField] internal int maxHealth;
    //[SerializeField] internal int health;

    [SerializeField] internal int defence;

    [SerializeField] internal int attackPower;

    [SerializeField] internal int traits;
}
