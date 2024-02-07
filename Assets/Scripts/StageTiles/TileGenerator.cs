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
            int i = Random.Range(0, tile_Ways.Count-1);
            latestTile = Instantiate(tile_Ways[i]);
            latestTile_Scroll = latestTile.GetComponent<TilesScroll>();
        }
    }
}
