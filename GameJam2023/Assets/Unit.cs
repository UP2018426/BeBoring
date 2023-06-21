using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] internal UnitScriptableObject unitScriptableObject;

    [Serializable] internal enum Formation { march, defence, attack };

    [SerializeField] internal Formation formation;



}
