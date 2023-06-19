using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/Unit", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    [SerializeField] internal string unitName;
    
    [SerializeField] internal int unitCount;

    [SerializeField] internal int health;
}
