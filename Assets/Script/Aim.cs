using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    //AimImageオブジェクトの情報を入れる箱を作る
    //AimImageオブジェクトには照準器の情報が入っている
    [SerializeField]
    private Image aimImage;

    void Update()
    {
        //レーザー（ray）を飛ばす「起点」と「方向」
        Ray ray = new Ray(transform.position, transform.forward);

        //レーザー光を可視化する
        Debug.DrawRay(transform.position, transform.forward * 60, Color.green);

        //rayのあたり判定の情報を入れる箱を作る
        RaycastHit hit;

        //
        if (Physics.Raycast(ray, out hit, 100))
        {
            //hitName 変数にrayが当たったゲームオブジェクトの座標の情報とタグの情報を入れる
            string hitName = hit.transform.gameObject.tag;

            //rayの当たった敵のタグにEnemyが入っていたら
            if (hitName == "Enemy") 
            {
                //照準器の色を「赤」に変える
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                //照準器の色を「水色」に変える
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            //照準器の色を「水色」に変える
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
