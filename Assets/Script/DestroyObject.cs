using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //エフェクト1を入れる箱を作る
    [SerializeField]
    private GameObject effectPrefab1;

    //エフェクト2を入れる箱を作る
    [SerializeField]
    private GameObject effectPrefab2;

    //objectHP 変数にHPの値を入れる
    public int objectHP;

    //アイテムをランダムに出現させる為に配列　[]　を使う。
    [SerializeField]
    private GameObject[] itemPrefab;

    //敵を倒すと得られる得点の値
    [SerializeField]
    private int scoreValue;

    //ScoreManagerコンポーネントの情報を入れる箱（sm 変数）を作る
    private ScoreManager sm;


    void Start()
    {
        //ScoreLabelオブジェクトに付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }

    /// <summary>
    /// このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //ぶつかった相手のTagにShellという名前が付いていたら（条件）
        if (other.CompareTag("Shell"))  
        {
            //オブジェクトのHPを１ずつ減少させる
            objectHP -= 1;

            //HPが０よりも大きい場合には（条件）
            if (objectHP > 0) 
            {
                //ぶつかってきたオブジェクトを破壊する
                Destroy(other.gameObject);

                //エフェクト1のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、
                //このスクリプトがアタッチしている,ゲームオブジェクトの位置にエフェクト1を無回転で生成し、
                //そのゲームオブジェクトの情報を左辺の effect 変数に代入することで制御を行える状態にする
                GameObject effect = Instantiate(effectPrefab1, other.transform.position, Quaternion.identity);

                //画面に表示しているエフェクト1をを2秒後に破棄する
                Destroy(effect, 2.0f);
            }
            //HPが０よりも小さい場合には（条件）
            else
            {
                //このゲームオブジェクトを破壊する
                Destroy(other.gameObject);

                //エフェクト2のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、
                //このスクリプトがアタッチしている,ゲームオブジェクトの位置にエフェクト2を無回転で生成し、
                //そのゲームオブジェクトの情報を左辺の effect2 変数に代入することで制御を行える状態にする
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);

                //画面に表示しているエフェクト2を2秒後に破壊する
                Destroy(effect2, 2.0f);

                //このスクリプトが付いているオブジェクトを破壊する
                Destroy(gameObject);

                //ランダムにアイテムを出現させるためにRandom 型のRange メソッドを使い、
                //このスクリプトが付いているゲームオブジェクトが破壊された時に複数あるアイテムプレファブの中の一つをランダムに出現させる
                //その情報をitemNumber 変数に代入する
                int itemNumber = Random.Range(0, itemPrefab.Length);

                //pos 変数にこのスクリプトが付いているゲームオブジェクトが破壊された時の座標を代入する
                Vector3 pos = transform.position;

                //このスクリプトの配列の中にアイテムプレファブが入っていたら（条件）
                if (itemPrefab.Length != 0)
                {
                    //pos.y + 0.6fの部分でアイテムの出現場所の『高さ』を調整している
                    //itemNumber 変数の中に入っている、ランダムにアイテムを出現させるためのRandom 型のRange メソッドと
                    //pos 変数に入っている、ゲームオブジェクトが破壊された時の座標を使い、
                    //このスクリプトが付いているゲームオブジェクトが破壊された座標にランダムにアイテムを出現させる
                    Instantiate(itemPrefab[itemNumber], new Vector3(pos.x, pos.y + 0.6f, pos.z), Quaternion.identity);
                }

                //sm 変数に入ってるScoreManageスクリプトの画面にSCOREを表示する情報を使い、
                //このスクリプトが付いているゲームオブジェクトが破棄されたら、設定したスコアを画面に表示する
                //（すでにスコアが付いていたらそのスコアに今回のスコアを足して表示する）
                sm.AddScore(scoreValue);
            }
        }
    }
}
