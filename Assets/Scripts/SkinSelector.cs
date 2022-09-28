using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject shop;

    public void SelectSkin(int skinId)
    {
        print("the selected skin Id is : " + skinId);
        //todo
        shop.SetActive(false);
    }
}
