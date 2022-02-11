using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.SetParent(other.gameObject.transform);

            other.gameObject.GetComponent<PlayerController>().SetListAlly(5);

            Destroy(this.gameObject);
        }
    }
}
