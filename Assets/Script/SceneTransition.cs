using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
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
        else if (Input.GetMouseButtonDown(0))
        {
            
        }
        else if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("GameScene");
        }


    }
    public void EndGame()
    {
        Application.Quit();
    }


}
