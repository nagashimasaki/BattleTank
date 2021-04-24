using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    //enemyPrefabの情報を入れる箱を作る
    [SerializeField]
    private GameObject enemyPrefab;

    //ターゲットにするゲームオブジェクトの情報を入れる箱を作る
    [SerializeField]
    private GameObject tagetTank;

    //時間の計測用の変数
    private int interval;

    //NavMeshAgent コンポーネントの情報を扱うための変数
    // private NavMeshAgent agent;

    public float divideTime;

    void Start()
    {
        //NavMeshAgentコンポーネントはゲームオブジェクトを自動的に移動させる情報を持っている
        //agent 変数でNavMeshAgentコンポーネントの情報を使えるようにする
       // agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        interval += 1;

        //interval 変数の値を 60 で割った計算結果の余りの値が 0 であるなら
        if (interval % divideTime == 0)
        {
            //
            GameObject enemyB = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            enemyB.GetComponent<ChaseEnemy>().target = tagetTank;
            //コンソールに「敵を生成」と表示する
            Debug.Log("敵を生成");
        }
        //ターゲットの情報が入っていたら
        //if (target != null)
        {
            //ターゲットの位置を目的地に設定する
            //agent.destination = target.transform.position;
        }
    }
}
