using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class setText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] text;

    [SerializeField] Unit unit;

    private void Update()
    { 
            text[0].text = unit.unitScriptableObject.unitName.ToString();
            text[1].text = unit.unitScriptableObject.maxHealth.ToString();
            text[2].text = unit.unitScriptableObject.formation.ToString();
            text[3].text = unit.unitScriptableObject.numberOfMoves.ToString();
            text[4].text = unit.unitScriptableObject.attackPower.ToString();
            text[5].text = unit.unitScriptableObject.range.ToString();
    }
}
