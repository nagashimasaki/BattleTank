using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //MainCamera ゲームオブジェクトにアタッチされている Camera コンポーネントの情報を代入する
    [SerializeField]
    private Camera mainCamera;

    //FPSCamera ゲームオブジェクトにアタッチされている Camera コンポーネントの情報を代入する
    [SerializeField]
    private Camera FPSCamera;

    //「bool」は「true」か「false」の二択の情報を扱うことができる
    //ボタンの操作を行った際に、使用するカメラを切り替える制御を行っている
    public bool mainCameraON = true;

    //MainカメラがONの時にmainListener変数で音を拾う
    //AudioListener コンポーネントを制御して切り替えるため
    //MainCamera (FPSCamera) ゲームオブジェクトをアサインし、
    //そのゲームオブジェクトにアタッチされている AudioListener 型の変数を代入し、制御するための変数
    [SerializeField]
    private AudioListener mainListener;

    //FPSカメラがONの時にFPSListener変数で音を拾う
    //AudioListener コンポーネントを制御して切り替えるため
    //MainCamera (FPSCamera) ゲームオブジェクトをアサインし、
    //そのゲームオブジェクトにアタッチされている AudioListener 型の変数を代入し、制御するための変数
    [SerializeField]
    private AudioListener FPSListener;

    //照準器のアイコンの表示/非表示の制御を行いたいので、
    //その制御を行いたいゲームオブジェクトの情報を代入しておく変数
    [SerializeField]
    private GameObject aimImage;
    
    void Start()
    {
        //Mainカメラをオンにする
        mainCamera.enabled = true;

        //FPSカメラをオフにする
        FPSCamera.enabled = false;

        //MainListenerをオンにする
        mainListener.enabled = true;

        //FPSListenerをオフにする
        FPSListener.enabled = false; 

        //FPSカメラがオンの時だけ、照準器（AimImageオブジェクト）もオンにする
        aimImage.SetActive(false);
    }

    void Update()
    {
        //キーボードのCボタンが押された時、MainカメラがONであるなら
        //メインカメラを使用している場合には true、使用していない場合には false
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            //Mainカメラをオフにする
            mainCamera.enabled = false;

            //FPSカメラをオンにする
            FPSCamera.enabled = true;

            //Mainカメラをオフにする
            mainCameraON = false;

            //MainListenerをオフにする
            mainListener.enabled = false;

            //FPSListenerをオンにする
            FPSListener.enabled = true;

            //照準器をオンにする
            aimImage.SetActive(true);
        }

        //キーボードのCボタンが押された時、かつ、MainカメラがOFFであるなら
        //メインカメラを使用している場合には true、使用していない場合には false
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            //Mainカメラをオンにする
            mainCamera.enabled = true;

            //FPSカメラをオフにする
            FPSCamera.enabled = false;

            //Mainカメラをオンにする
            mainCameraON = true;

            //MainListenerをオンにする
            mainListener.enabled = true; 

            //FPSListenerをオフにする
            FPSListener.enabled = false; 

            //照準器をオフにする
            aimImage.SetActive(false);
        }
    }
}
