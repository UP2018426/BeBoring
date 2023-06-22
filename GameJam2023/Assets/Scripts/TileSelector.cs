using Unity.VisualScripting;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] Material HoverMat;

    [SerializeField] Material thisMaterial;

    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] GameObject unit;


    public bool selectable;

    public GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        thisMaterial = meshRenderer.material;//can be changed if need multiple materials
    }








    private void OnMouseOver()
    {
        if (Cursor.visible && selectable)
            meshRenderer.material = HoverMat;

        if (Input.GetMouseButtonUp(0) && Cursor.visible && selectable)
        {
            if (gm.selectedUnit.GetComponent<PathLogic>().numOfMoves > 0 && gm.p1Turn)
            {
                gm.playerAMoves.Add(new GameManager.TroopCommands(GameManager.MoveType.Move, gm.selectedUnit.transform.position, transform.position,gm.selectedUnit));
                gm.selectedUnit.transform.position = transform.position;
                gm.selectedUnit.GetComponent<PathLogic>().numOfMoves--;
            }
            else if (gm.selectedUnit.GetComponent<PathLogic>().numOfMoves > 0 &! gm.p1Turn)
            {
                gm.playerBMoves.Add(new GameManager.TroopCommands(GameManager.MoveType.Move, gm.selectedUnit.transform.position, transform.position, gm.selectedUnit));
                gm.selectedUnit.transform.position = transform.position;
                gm.selectedUnit.GetComponent<PathLogic>().numOfMoves--;
            }

            //Debug.Log("SHID");

            //Instantiate(unit,transform.position,Quaternion.identity);
        }
    }

    private void OnMouseExit()
    {
        meshRenderer.material = thisMaterial;
    }

    private void Reset()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}
