using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;
    //privateの状態でもInspector上から設定できるようにするテクニック。
    [SerializeField]
    private GameObject shellPrefab = null;
    [SerializeField]
    private AudioClip shotSound = null;
    private float timeBetweenShot = 0.75f;
    private float timer;
    public int shotCount;
    [SerializeField]
    private Text shellLabel;
    public int shotMaxCount = 20;

    void Start()
    {
        shotCount = shotMaxCount;
        shellLabel.text = "砲弾:" + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime; //タイマーの時間を動かす
        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot && shotCount > 0)   //もしもSpaceキーを押したならば（条件）,Space」の部分を変更することで他にキーにすることができる
        {
            shotCount -= 1;
            shellLabel.text = "砲弾:" + shotCount;
            timer = 0.0f; //タイマーの時間を０に戻す
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity); //砲弾のプレハブを実体化（インスタンス化）する
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();  //砲弾に付いているRigidbodyコンポーネントにアクセスする
            shellRb.AddForce(transform.forward * shotSpeed); //forward（青軸＝z軸）の方向に力を加える。
            Destroy(shell, 3.0f); //発射した砲弾を３秒後に破壊する,不要になった砲弾はメモリー上から削除する                                
            AudioSource.PlayClipAtPoint(shotSound, transform.position); //砲弾の発射音を出す
        }
    }

    public void AddShell(int amount)
    {
        shotCount += amount; //

        if(shotCount > shotMaxCount) //
        {
            shotCount = shotMaxCount;
        }
        shellLabel.text = "砲弾:" + shotCount;
    }
}
