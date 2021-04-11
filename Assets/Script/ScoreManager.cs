using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private Text scoreLabel;
    
    void Start()
    {
        //Textコンポーネントを呼び出して使えるようにする。
        scoreLabel = GetComponent<Text>();
        //呼び出したTextコンポーネントを使う
        scoreLabel.text = "SCORE:" + score;       
    }

    /// <summary>
    /// 画面にSCOREを表示
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE:" + score;
    }
}
