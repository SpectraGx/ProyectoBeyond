using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAssets : MonoBehaviour
{
    private static gameAssets _i;

    public static gameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("gameAssets")) as GameObject).GetComponent<gameAssets>();
            return _i;
        }
    }

    public Sprite s_Armor_1;
}
