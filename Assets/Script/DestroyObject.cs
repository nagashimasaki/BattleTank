using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;
    [SerializeField]
    private GameObject effectPrefab2;
    public int objectHP;

    //アイテムをランダムに出現させる為に配列　[]　を使う。
    [SerializeField]
    private GameObject[] itemPrefab;
    //敵を倒すと得られる得点
    [SerializeField]
    private int scoreValue;
    private ScoreManager sm;


    void Start()
    {
        //ScoreLabelオブジェクトに付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)//このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    {       
        if (other.CompareTag("Shell"))  //もしもぶつかった相手のTagにShellという名前が付いていたら（条件）
        {
            objectHP -= 1;　//オブジェクトのHPを１ずつ減少させる
            if (objectHP > 0)  //もしもHPが０よりも大きい場合には（条件）
            {
                Destroy(other.gameObject);  //ぶつかってきたオブジェクトを破壊する。
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
            }
            else
            {
                Destroy(other.gameObject);
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);
                Destroy(gameObject);  //このスクリプトが付いているオブジェクトを破壊する。

                int itemNumber = Random.Range(0, itemPrefab.Length);
                Vector3 pos = transform.position;
                if (itemPrefab.Length != 0)
                {
                    //pos.y + 0.6fの部分でアイテムの出現場所の『高さ』を調整している。
                    Instantiate(itemPrefab[itemNumber], new Vector3(pos.x, pos.y + 0.6f, pos.z), Quaternion.identity);
                }
                sm.AddScore(scoreValue);
            }
        }
    }
}
