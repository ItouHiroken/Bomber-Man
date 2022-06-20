//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnMonoOtosuhito : MonoBehaviour
//{
//    [SerializeField][Tooltip("0秒に戻す用のやつ")] private float _targetTime = default;
//    [SerializeField][Tooltip("召喚する時間")] private float _currentTime = default;
//    [Tooltip("爆発のエフェクトを持ってくるよ！")] public GameObject explosionPrefab;
//    private void Update()
//    {
//        _currentTime += Time.deltaTime;
//        if (_targetTime < _currentTime)
//        {
//            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

//            _currentTime = 0;
//        }
//    }
//}
