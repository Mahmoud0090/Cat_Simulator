using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    string[] names = {"Skitty", "Felina", "YoYo", "Certo", "Lionel", "Mocha", "Frannie", "Pepper",
            "Roy", "Teejay", "Victor", "Mimi", "Taylor" , "Rocoso" , "Ginger" , "Tora" };
    private void Awake()
    {
        this.gameObject.name = names[Random.Range(0, names.Length)];
    }
}
