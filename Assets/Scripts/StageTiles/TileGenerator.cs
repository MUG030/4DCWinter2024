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
    void Start()
    {
        latestTile = tile_Departure;
        Test();
    }
    void Update()
    {
    }

    void Test()
    {
        float _tileamount = tile_Ways_Amount;
        for(int j = 0; j < _tileamount; j++)
        {
            if(tile_Ways_Amount > 1)
            {
                int i = Random.Range(0, tile_Ways.Count);
                --tile_Ways_Amount;
                latestTile = Instantiate(tile_Ways[i], new Vector3(j*69+32f, 0, 0), Quaternion.identity);
                Debug.Log($"j:{j}, tileAmount:{tile_Ways_Amount}");
            }
            if(tile_Ways_Amount == 1)
            {
                Debug.Log("Last");
                latestTile = Instantiate(tile_Goal, new Vector3((j+1)*69+32f, 0, 0), Quaternion.identity);
            }
        }

    }
}
