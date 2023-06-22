using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/Unit", order = 0)]
public class UnitScriptableObject : ScriptableObject
{
    [SerializeField] internal string unitName;

    [SerializeField] internal GameObject model;

    [SerializeField] internal int maxHealth;
    [Serializable] internal enum Formation { march,defence,attack};

    [SerializeField] internal Formation formation;

    [SerializeField] internal int numberOfMoves;

    [SerializeField] internal int attackPower;

    [SerializeField] internal int range;

}
