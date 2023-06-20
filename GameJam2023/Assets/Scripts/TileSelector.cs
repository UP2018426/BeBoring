using Unity.VisualScripting;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] Material HoverMat;

    [SerializeField] Material thisMaterial;

    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] GameObject unit;



    private void Awake()
    {
        thisMaterial = meshRenderer.material;//can be changed if need multiple materials
    }




    




    private void OnMouseEnter()
    {
        meshRenderer.material = HoverMat;

        if (Input.GetMouseButton(0))
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
