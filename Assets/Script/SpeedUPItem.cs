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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TankMovement>().ChengMoveSpped(sppedUP);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
