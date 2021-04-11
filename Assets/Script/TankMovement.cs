using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Header("戦車の動く速さ")]
    public float moveSpeed;
    [Header("戦車の旋回する速さ")]
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    private float defaultMoveSpped;   
    //インスペクターで操作する時にどこの操作をする部分か分かるように付ける
    [Header("移動速度変更の持続時間")]
    public float duration;
    public float timer = 0f;
    public bool isChengSpped;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //現在のスピードを保存
        defaultMoveSpped = moveSpeed;
    }
    
    void Update()
    {
        TankMove();
        TankTurn();

        //移動速度が変更中だったら
        if (isChengSpped == true) 
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                //変更時間が終了したから速度を戻す
                DefaltMoveSpped();
            }
        }
    }

    /// <summary>
    /// 前進・後退のメソッド
    /// </summary>
    void TankMove() 
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    /// <summary>
    /// 旋回のメソッド
    /// </summary>
    void TankTurn()  
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    /// <summary>
    /// 移動速度を変更
    /// </summary>
    /// <param name="newMoveSpped"></param>
    public void ChengMoveSpped(float newMoveSpped)
    {
        //移動速度を変更中の状態にする
        isChengSpped = true;
        //変更時間をセット
        timer = duration;       
        //新しいスピードに変更
        moveSpeed = newMoveSpped;
        Debug.Log("移動スピード変更:" + moveSpeed);
    }

    /// <summary>
    /// 移動速度を元に戻す
    /// </summary>
    public void DefaltMoveSpped()
    {
        //移動速度を変更中ではない状態にする
        isChengSpped = false;
        moveSpeed = defaultMoveSpped;
        Debug.Log("移動スピード変更:" + moveSpeed);
    }
}
