using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PathLogic : MonoBehaviour
{
    private bool inPlay;
    public List<Collider> neighbours;
    public List<Collider> surroundingunits = new();
    [SerializeField] private GameObject currentPos;

    [SerializeField] internal UnitScriptableObject unit;

    [SerializeField] internal int numOfMoves;
    [SerializeField] public int health;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = true;
        numOfMoves = unit.numberOfMoves;
        health = unit.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNeighbours();
        transform.position = currentPos.transform.position;


        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //nearunits();
    }

    void CheckNeighbours()
    {
        for (int i = 0; i < neighbours.Count; i++)
        {
            neighbours[i].GetComponent<TileSelector>().selectable = false;
        }

        neighbours = Physics.OverlapBox(transform.position, Vector3.one, Quaternion.identity, LayerMask.GetMask("Water")).ToList();

        float temp = Mathf.Infinity;

        for (int i = 0; i < neighbours.Count; i++)
        {
            neighbours[i].GetComponent<TileSelector>().selectable = true;
            if ((neighbours[i].gameObject.transform.position - transform.position).magnitude < temp)
            {
                temp = (neighbours[i].gameObject.transform.position - transform.position).magnitude;
                currentPos = neighbours[i].gameObject;
            }
        }
        for (int i = 0; i < neighbours.Count; i++)
        {
            if (neighbours[i].gameObject == currentPos)
            {
                neighbours[i].GetComponent<TileSelector>().selectable = false;
                neighbours.RemoveAt(i);
            }
        }
    }

    //[SerializeField] LayerMask friend;
    [SerializeField] string enemy;

    internal void nearunits()
    {
        surroundingunits.Clear();
        
        
        //MAY TAKE FORM GAME MANAGER AND GIVE THE UNITS TAG THEN JUST COMPARE IF IT HAS TEH RIGHT TAG
        surroundingunits = Physics.OverlapBox(transform.position + new Vector3(0, 1, 0), new Vector3(1, 0.5f, 1 ) * unit.range, Quaternion.identity, LayerMask.GetMask("Player")).ToList();

        //float temp = Mathf.Infinity;
        //var enemies = new List<GameObject>();

        if (surroundingunits.Count > 0)
        {
            for (int i = 0; i < surroundingunits.Count; i++)
            {
                if (surroundingunits[i].CompareTag(enemy))
                {
                    surroundingunits[i].GetComponent<PathLogic>().health -= unit.attackPower;

                    //surroundingunits.Remove(surroundingunits[i]);
                }
            }

        }



        //for (int i = 0; i < neighbours.Count; i++)
        //{
        //    //surroundingunits[i].GetComponent<TileSelector>().selectable = true;
        //    if((surroundingunits[i].gameObject.transform.position - transform.position).magnitude < temp)
        //    {
        //        temp = (surroundingunits[i].gameObject.transform.position - transform.position).magnitude;
        //        //currentPos = neighbours[i].gameObject;
        //    }
        //}
        //for (int i = 0; i < neighbours.Count; i++)
        //{
        //    //if (surroundingunits[i].gameObject == currentPos)
        //    {
        //        //neighbours[i].GetComponent<TileSelector>().selectable = false;
        //        //neighbours.RemoveAt(i);
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        if (inPlay)
        {
            Gizmos.color = new Color(0, 0, 1, 0.25f);
            Gizmos.DrawSphere(currentPos.transform.position, 0.4f);
            Gizmos.color = new Color(1, 0, 0, 0.25f);

            for (int i = 0; i < neighbours.Count; i++)
            {
                Gizmos.DrawSphere(neighbours[i].transform.position, 0.4f);
            }

            Gizmos.DrawWireCube(transform.position + new Vector3(0, 1, 0), new Vector3(1, 0.5f, 1) * unit.range);
        }
    }
}
