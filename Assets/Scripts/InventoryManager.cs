using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public int bread, water, medkit, beer, cigarette;
    public TextMeshProUGUI breadTmp, waterTmp, medkitTmp, beerTmp, cigaretteTmp;

    void Update() // envanterde yer alan e�ya say�lar�n�n anl�k olarak aray�z ile e�le�tirilmesi.
    {
        breadTmp.text = bread.ToString();
        waterTmp.text = water.ToString();
        medkitTmp.text = medkit.ToString();
        beerTmp.text = beer.ToString();
        cigaretteTmp.text = cigarette.ToString();
    }
}
