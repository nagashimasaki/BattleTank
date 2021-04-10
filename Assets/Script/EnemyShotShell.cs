using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    [SerializeField]
    private GameObject enemyShellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    private int interval;
    public float stopTimer = 5.0f;
    [SerializeField]
    private Text stopLabel;

    void Update()
    {
        interval += 1;

        stopTimer -= Time.deltaTime;
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        stopLabel.text = "" + stopTimer.ToString("0");

        if (interval % 60 == 0 && stopTimer <= 0) 
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();
            enemyShellRb.AddForce(transform.forward * shotSpeed);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
            Destroy(enemyShell, 3.0f);
        }
    }
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;
        stopLabel.text = "" + stopTimer.ToString("0");
    }
}
