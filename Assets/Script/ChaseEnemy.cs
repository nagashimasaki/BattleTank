using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    //ターゲットにするゲームオブジェクトの情報を入れる箱を作る
    [SerializeField]
    public GameObject target;

    //NavMeshAgent コンポーネントの情報を扱うための変数
    private NavMeshAgent agent;
    
    void Start()
    {
        //NavMeshAgentコンポーネントはゲームオブジェクトを自動的に移動させる情報を持っている
        //agent 変数でNavMeshAgentコンポーネントの情報を使えるようにする
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //ターゲットの情報が入っていたら
        if (target != null) 
        {
            //ターゲットの位置を目的地に設定する
            agent.destination = target.transform.position; 
        }
    }
}
