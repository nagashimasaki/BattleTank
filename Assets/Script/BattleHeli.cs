using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeli : MonoBehaviour
{
    //targetにするゲームオブジェクトの情報を入れる箱を作る
    public GameObject target;

    //ゲームオブジェクトのBattleHeriに付いているenemyShotShellの情報を入れる箱を作る
    public GameObject enemyShotShell;

    //enemyShellのPrefabの情報を入れる箱を作る
    public GameObject enemyShellPrefab;

    //敵の球が生成されるまでの時間の情報を入れる箱を作る
    public int count = 0;

    void Update()
    {
        //常にターゲットの方を向く。
        transform.LookAt(target.transform);

        //このスクリプトが付いているゲームオブジェクトの座標とターゲットの座標の差分が20より大きく離れていたら
        if (Vector3.Distance(transform.position, target.transform.position) > 20f)  
        {
            //if文の条件が満たされて、処理が実行されたらコンソールに「移動」と表示する
            Debug.Log("移動");

            //
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        }
        else
        {
            //一定距離に近づいたら機体の高度を上げる。
            if (transform.position.y < 8f)
            {
                //if文の条件が満たされて、処理が実行されたらコンソールに「高度上昇」と表示する
                Debug.Log("高度上昇");

                //
                transform.Translate(Vector3.up * Time.deltaTime * 3);
            }

            //攻撃開始

            //時間を1ずつ加算する
            count += 1;

            //count 変数の値を 60 で割った計算結果の余りの値が 0 であったら
            if (count % 60 == 0)
            {
                //if文の条件が満たされて、処理が実行されたらコンソールに「球を発射」と表示する
                Debug.Log("球を発射");

                //敵の弾のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、このスクリプトがアタッチしている
                //ゲームオブジェクトのenemyShotShellの位置にenemyShotShellを無回転で生成し、そのゲームオブジェクトの情報を
                //左辺の enemyShell 変数に代入することで制御を行える状態にする
                GameObject enemyShell = Instantiate(enemyShellPrefab, enemyShotShell.transform.position,enemyShotShell.transform.rotation);

                //enemyShell 変数内に代入されている弾のゲームオブジェクトに
                //アタッチされているRigidbodyコンポーネントの情報をenemyShellRb変数に代入する
                Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

                //enemyShellRB 変数に代入されている Rigidbody 型(クラス)の情報を使って、この Rigidbody 型(クラス)にある
                //AddForce メソッドを実行して、弾に力を加えて動かす
                enemyShellRb.AddForce(transform.forward * 500);
            }
        }
    }
}
