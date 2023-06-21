using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceUnitPicker : MonoBehaviour
{
    [SerializeField] UnitScriptableObject unitScriptableObject;

    Button button;

    [SerializeField] Color col;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(placeUnitStart);
    }

    void placeUnitStart()
    {
        var tmp = FindObjectOfType<GameManager>();
        tmp.placing = true;
        tmp.tmpColour = col;
        tmp.unitTypeToPass = unitScriptableObject;
    }
}
