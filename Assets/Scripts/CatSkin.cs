using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkin : MonoBehaviour
{
    public Texture2D[] skins;
    public Material catMaterials;
    public int selectedSkin;

    private void Awake()
    {
        selectedSkin = PlayerPrefs.GetInt("SelectedSkin" , 0);
        catMaterials.mainTexture = skins[selectedSkin];
    }

    public void SetSkin(int skinId)
    {
        catMaterials.mainTexture = skins[skinId];
    }
}
