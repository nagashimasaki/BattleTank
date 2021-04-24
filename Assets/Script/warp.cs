using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    //移動先の情報
    [SerializeField]
    private GameObject destinationPos;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //侵入してきたゲームオブジェクトがプレイヤーだったら
        if (other.gameObject.tag == "Player")
        {
            //指定した地点に移動させる
            other.gameObject.transform.position = destinationPos.transform.position;
        }
    }
}
