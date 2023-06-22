using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    internal static GameManager instance;
    public GameObject selectedUnit;

    [SerializeField] internal bool p1Turn = true;

    public List<TroopCommands> playerAMoves = new List<TroopCommands>();
    public List<TroopCommands> playerBMoves = new List<TroopCommands>();
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

    Camera cam;
    [SerializeField] LayerMask mask;
    [SerializeField] LayerMask mask2;
    [SerializeField] internal bool placing;
    [SerializeField] internal UnitScriptableObject unitTypeToPass;

    [SerializeField] internal GameObject prefabUnit;
    internal Color tmpColour;

    private void Awake()
    {
        cam = Camera.main;
    }

    public  void PlayerMoveInputChange()
    {
        if (p1Turn)
        {
            p1Turn = false;
        }
        else
        {
            p1Turn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerAMoves.Count);
        GetMapState();

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
                hit.transform.GetComponent<Renderer>().material.color = Color.red;

                selectedUnit = hit.transform.gameObject;
            }
            else if (hit.collider == null && selectedUnit != null)
            {
                selectedUnit.GetComponent<Renderer>().material.color = Color.white;
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
    }

    void GetMapState()
    {
        //allTroops.Clear();
        var temp = GameObject.FindGameObjectsWithTag("Unit");

        for (int i = 0; i < /*GameObject.FindGameObjectsWithTag("Unit")*/temp.Length; i++)
        {
            allTroops.Add(/*GameObject.FindGameObjectsWithTag("Unit")*/temp[i].transform.position);
        }
    }

}
