using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Result : MonoBehaviour
{
  //  public GameObject scene;
    [SerializeField][Tooltip("時間数えてくれるマン")] float _s = default;
    [SerializeField][Tooltip("何秒後にスタートシーンに戻るかマン")] float _i = default;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
        _s += Time.deltaTime;
       
        if (_i <= _s)
        {
            SceneManager.LoadScene("GameStart");
            _s = 0;
        }

    }
}
