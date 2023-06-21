using Unity.VisualScripting;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] Material HoverMat;

    [SerializeField] Material thisMaterial;

    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] GameObject unit;

    public bool selectable;



    private void Awake()
    {
        thisMaterial = meshRenderer.material;//can be changed if need multiple materials
    }




    

        


    private void OnMouseEnter()
    {
        if(Cursor.visible)
            meshRenderer.material = HoverMat;

        if (Input.GetMouseButton(0) && Cursor.visible && selectable)
        {
            Instantiate(unit,transform.position,Quaternion.identity);
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
