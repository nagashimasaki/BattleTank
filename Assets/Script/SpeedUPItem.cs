using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUPItem : MonoBehaviour
{
    private GameObject[] targets;
    [SerializeField]
    private AudioClip getSound;
    [SerializeField]
    private GameObject effectPrefab;
    public float sppedUP = 10.0f;
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //for (int i = 0; i < targets.Length; i++)
            //{
            //    //targets[i].GetComponent<TankMovement>().(5.0f);
            //}
            other.gameObject.GetComponent<TankMovement>().ChengMoveSpped(sppedUP);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
