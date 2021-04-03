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
            }
        }
    }
}
