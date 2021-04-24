using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public void OnStartButtonClicked()
    {
        //
        SceneManager.LoadScene("Main");
    }
}
