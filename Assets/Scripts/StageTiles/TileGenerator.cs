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
    private int tile_Ways_Amount = 1;
    private GameObject latestTile;
    private TilesScroll latestTile_Scroll;
    void Start()
    {
        latestTile = tile_Departure;
        latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
    }
    void Update()
    {
        if(latestTile_Scroll.isAllChildVisible)
        {
            if(tile_Ways_Amount > 0)
            {
                int i = Random.Range(0, tile_Ways.Count);
                latestTile = Instantiate(tile_Ways[i]);
                latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
                --tile_Ways_Amount;
                Debug.Log(tile_Ways_Amount);
            }
            if(tile_Ways_Amount == 0)
            {
                Debug.Log("Last");
                latestTile = Instantiate(tile_Goal);
                latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
            }
        }
    }
}
