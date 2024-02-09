using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCatalog : MonoBehaviour
{
    [SerializeField] private GameObject beforeObject;
    [SerializeField] private GameObject afterObject;

    void Start()
    {
        beforeObject.SetActive(true);
        //afterObject.SetActive(false);

        Invoke("ChangeCatalog", 10.0f);
    }

    private void ChangeCatalog()
    {
        beforeObject.SetActive(false);
        //afterObject.SetActive(true);
    }
}
