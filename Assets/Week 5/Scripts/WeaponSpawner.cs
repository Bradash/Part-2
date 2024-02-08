using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject katana;

    public void spawnKatana()
    {
        Instantiate(katana);
    }
}
