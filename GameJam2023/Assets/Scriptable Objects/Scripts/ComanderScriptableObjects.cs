using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comander", menuName = "ScriptableObjects/Comander", order = 1)]
public class ComanderScriptableObjects : ScriptableObject
{
    [SerializeField] internal string unitName;

    [SerializeField] internal int magic;

}
