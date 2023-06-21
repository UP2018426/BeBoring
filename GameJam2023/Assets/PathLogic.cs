using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PathLogic : MonoBehaviour
{
    private bool inPlay;
    public Collider[] neighbours;
    private GameObject currentPos;
    // Start is called before the first frame update
    void Start()
    {
        inPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNeighbours();
        transform.position = currentPos.transform.position;
    }

    void CheckNeighbours()
    {
        neighbours = Physics.OverlapBox(transform.position, Vector3.one, Quaternion.identity, LayerMask.GetMask("Water"));
        
        float temp = Mathf.Infinity;
        
        for (int i = 0; i < neighbours.Length; i++)
        {
            neighbours[i].GetComponent<TileSelector>().selectable = true;
            if((neighbours[i].gameObject.transform.position - transform.position).magnitude < temp)
            {
                temp = (neighbours[i].gameObject.transform.position - transform.position).magnitude;
                currentPos = neighbours[i].gameObject;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (inPlay)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(currentPos.transform.position, 0.8f);
            Gizmos.color = Color.red;

            for (int i = 0; i < neighbours.Length; i++)
            {
                Gizmos.DrawSphere(neighbours[i].transform.position, 0.8f);
            }

            Gizmos.DrawWireCube(transform.position, transform.forward);
        }
    }
}
