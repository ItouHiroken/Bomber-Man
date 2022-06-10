using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{   
    [SerializeField] PlayerControll controller1;
    [SerializeField] Player2Controll controller2;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetActive(false); // gameObject���A�N�e�B�u��
            controller1.enabled = true; 
            controller2.enabled = true;
        }
    }
}
