using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    internal static GameManager instance;
    public GameObject selectedUnit;

    [SerializeField] internal bool p1Turn = true;

    public List<TroopCommands> playerAMoves = new List<TroopCommands>();
    public List<TroopCommands> playerBMoves = new List<TroopCommands>();
    public List<Vector3> allTroops = new List<Vector3>();
    public List<GameObject> allTroopsobj = new();

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
        internal MoveType moveType;
        internal Vector3 CurrentPos;
        internal Vector3 targetPos;
        internal GameObject gamObj;
        public TroopCommands(MoveType moveType, Vector3 CurrentPos, Vector3 pos, GameObject gamObjec)
        {
            this.moveType = moveType;
            this.CurrentPos = CurrentPos;
            this.targetPos = pos;
            gamObj = gamObjec;
        }
    }

    Camera cam;
    [SerializeField] internal LayerMask mask;
    [SerializeField] LayerMask mask2;
    [SerializeField] internal bool placing;
    [SerializeField] internal UnitScriptableObject unitTypeToPass;

    [SerializeField] internal GameObject prefabUnit;
    internal Color tmpColour;

    private void Awake()
    {
        cam = Camera.main;

        GetMapState();
        SetMapState();
    }

    public  void PlayerMoveInputChange()
    {
        if (p1Turn == true)
        {
            p1Turn = false;
        }
        else if (p1Turn == false)
        {
            p1Turn = true;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"player 1 move count {playerAMoves.Count}");
        Debug.Log($"player 2 move count {playerBMoves.Count}");
        //GetMapState();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(cam.transform.position, mousePos - transform.position,
        Color.blue);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Debug.Log(hit.transform.name);
                //hit.transform.GetComponent<Renderer>().material.color = Color.red;

                selectedUnit = hit.transform.gameObject;
            }
            else if (hit.collider == null && selectedUnit != null)
            {
                //selectedUnit.GetComponent<Renderer>().material.color = Color.white;
                selectedUnit = null;
            }


            if (Physics.Raycast(ray, out hit, 100, mask2) && placing)
            {
                var tmp = Instantiate(prefabUnit, hit.transform.position, Quaternion.identity);
                tmp.GetComponent<PathLogic>().unit = unitTypeToPass;
                //tmp.GetComponent<Renderer>().material.color = tmpColour;

                placing = false;
            }
        }
        if (p1Turn && playerinputingMoves != null)
        {
            playerinputingMoves.text = ("Blue Moves");
        }
        else if (!p1Turn && playerinputingMoves != null)
        {
            playerinputingMoves.text = ("Red Moves");
        }
    }

    public void SetMapState()
    {
        for (int i = 0; i < allTroops.Count; i++)
        {
            allTroopsobj[i].transform.position = allTroops[i];
        }
    }

    public void GetMapState()
    {
        allTroopsobj.Clear();
        allTroops.Clear();

        var temp = GameObject.FindObjectsOfType<PathLogic>();

        for (int i = 0; i < /*GameObject.FindGameObjectsWithTag("Unit")*/temp.Length; i++)
        {
            allTroops.Add(/*GameObject.FindGameObjectsWithTag("Unit")*/temp[i].transform.position);
            allTroopsobj.Add(/*GameObject.FindGameObjectsWithTag("Unit")*/temp[i].gameObject);
        }
    }

    public void deselectSelecetedUnit()
    {
        selectedUnit = null;
    }

    [SerializeField] TextMeshProUGUI playerinputingMoves;

}
