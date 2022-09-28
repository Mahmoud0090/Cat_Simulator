using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject shop;
    public CatSkin catSkin;

    public void SelectSkin(int skinId)
    {
        print("the selected skin Id is : " + skinId);
        PlayerPrefs.SetInt("SelectedSkin", skinId);
        catSkin.SetSkin(skinId);
        shop.SetActive(false);
    }
}
