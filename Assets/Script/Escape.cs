using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Escape : MonoBehaviour
{
    public GameObject scene;
    public GameObject Esc;
    private void Start()
    {
        Esc.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.SetActive(true);
        }
    }
        public void StartScene()
        {
            SceneManager.LoadScene("GameStart");
       
        }
}
