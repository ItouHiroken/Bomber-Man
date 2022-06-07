using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlast : MonoBehaviour
{
    public int _bombDamage;
    void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
