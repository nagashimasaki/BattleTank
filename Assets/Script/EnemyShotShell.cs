using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    //砲弾のスピード
    public float shotSpeed;

    //複製対象のゲームオブジェクト
    [SerializeField]
    private GameObject enemyShellPrefab;

    //砲弾を打つときの音
    [SerializeField]
    private AudioClip shotSound;

    //時間の計測用の変数
    private int interval;

    //敵が攻撃を停止している時間
    public float stopTimer = 5.0f;

    //敵が弾の生成を停止している時間を、ゲーム画面に表示させるための制御を行う Text 型の情報を代入する変数
    [SerializeField]
    private Text stopLabel;

    void Update()
    {
        //時間を1ずつ加算する
        interval += 1;

        //stopTimerの値を減算する
        stopTimer -= Time.deltaTime;

        //stopTimerの値が0より小さかったら
        if (stopTimer < 0)
        {
            //stopTimerに0を代入する
            stopTimer = 0;
        }
        //stopTimer 変数の情報を ToString メソッドを利用して float 型から string 型に変化し、小数点を表示しないようにしたうえで
        //Text 型の stopLabel 変数の text(string 型)に代入する
        stopLabel.text = "" + stopTimer.ToString("0");

        //interval 変数の値を 60 で割った計算結果の余りの値が 0 であり、かつ、stopTimer 変数の値が 0 か、0 以下であるなら
        if (interval % 60 == 0 && stopTimer <= 0) 
        {
            //敵の弾のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、このスクリプトがアタッチしている
            //ゲームオブジェクトの位置に無回転の状態で生成し、そのゲームオブジェクトの情報を左辺の enemyShell 変数に代入することで
            //制御を行える状態にする
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            //enemyShellの中にあるRigidbodyコンポーネントの情報をenemyShellRb変数に代入する
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            //enemyShellRb変数の情報のAddForceメソッドで砲弾に力を加え続ける
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            //鳴らしたいオーディオクリップ（shotSound）と座標を引数に指定して、指定した場所に新しく一時オブジェクトを生成し、効果音を鳴らす
            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            //enemyShelオブジェクトを3秒後に破壊する
            Destroy(enemyShell, 3.0f);
        }
    }
    /// <summary>
    /// stopTimer変数に敵が攻撃を停止している時間を代入し、その値をText 型の stopLabel 変数の text(string 型)に代入する
    /// </summary>
    /// <param name="amount"></param>
    public void AddStopTimer(float amount)
    {
        //amount引数（何秒攻撃を止めるか）の情報をstopTimer変数に代入する
        stopTimer += amount;

        ////stopTimer 変数の情報を ToString メソッドを利用して float 型から string 型に変化し、小数点を表示しないようにしたうえで
        //Text 型の stopLabel 変数の text(string 型)に代入する
        stopLabel.text = "" + stopTimer.ToString("0");
    }
}
