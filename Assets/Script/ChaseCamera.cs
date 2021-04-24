using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    //ターゲットにするゲームオブジェクトを入れる箱を来る
    [SerializeField]
    private GameObject target;

    //カメラとターゲットの座標の差分を入れる箱を作る（カメラとターゲットの距離）
    private Vector3 offset;
   
    void Start()
    {
        //カメラとターゲットの最初の位置関係（距離）を取得する
        offset = transform.position - target.transform.position; 
    }

    void Update()
    {
        //ターゲットの情報が入っていたら
        if (target != null)
        {
            //最初に取得した位置関係を足すことで常に一定の距離を維持する
            transform.position = target.transform.position + offset; 
        }       
    }
}
