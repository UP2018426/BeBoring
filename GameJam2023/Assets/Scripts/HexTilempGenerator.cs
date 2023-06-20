using UnityEngine;

public class HexTilempGenerator : MonoBehaviour
{
    //These values work fine the the dimensions fo the flat tiles

    [SerializeField] int width = 10, height = 10;

    [SerializeField] GameObject[] Hexagons;

    [SerializeField] float tileOfsetX = 1.7f, tileOfsetZ = 0.5f;

    [SerializeField] Transform tileContainer;

    void Start()
    {

        CreateTilemap();
    }



    private void CreateTilemap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GameObject tmp = Instantiate(Hexagons[Random.Range(0, Hexagons.Length - 1)]);
                tmp.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                if (z % 2 == 0)
                {
                    tmp.transform.position = new Vector3(x * tileOfsetX, 0, z * tileOfsetZ);
                }
                else
                {
                    tmp.transform.position = new Vector3(x * tileOfsetX + tileOfsetX / 2, 0, z * tileOfsetZ);
                }
                SetTileInfo(tmp, x, z);
            }
        }
    }

    void SetTileInfo(GameObject tile, int x, int z)
    {
        tile.transform.parent = tileContainer;

        tile.name = new string($"{x},{z}");
    }
}
