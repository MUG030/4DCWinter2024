using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject tile_Departure;
    [SerializeField]
    private GameObject tile_Goal;
    [SerializeField]
    private List<GameObject> tile_Ways;
    [SerializeField]
    public int tile_Ways_Amount = 1;
    private GameObject latestTile;
    private TilesScroll latestTile_Scroll;
    void Start()
    {
        latestTile = tile_Departure;
        latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
        Test();
    }
    void Update()
    {
    }

    void Test()
    {
        for(int j = 0; j < tile_Ways_Amount; j++)
        {
            if(tile_Ways_Amount > 1)
            {
                int i = Random.Range(0, tile_Ways.Count);
                --tile_Ways_Amount;
                latestTile = Instantiate(tile_Ways[i], new Vector3(j*69+17.5f, 0, 0), Quaternion.identity);
                latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
                Debug.Log(tile_Ways_Amount);
            }
            if(tile_Ways_Amount == 1)
            {
                Debug.Log("Last");
                latestTile = Instantiate(tile_Goal, new Vector3((j+1)*69+17.5f, 0, 0), Quaternion.identity);
                latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
            }
        }

    }
}
