using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private float defaultMoveSpped;
    public float timer = 0f;
    [Header("移動速度変更の持続時間")]
    public float duration;
    public bool isCengSpped;

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
        if (isCengSpped == true) 
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
   
    void TankMove() //前進・後退のメソッド
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
  
    void TankTurn()  //旋回のメソッド
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
        isCengSpped = true;
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
        isCengSpped = false;
        moveSpeed = defaultMoveSpped;
        Debug.Log("移動スピード変更:" + moveSpeed);
    }
}
