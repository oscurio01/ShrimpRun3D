using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTrident : MonoBehaviour
{
    bool onlyOnce = false;
    float timer = 0;
    float secondTimer = 0;
    Quaternion initialRotation;

    Transform childTrident;
    Vector3 originalPosition;
    Rigidbody rb;
    private void OnEnable()
    {
        timer = 5f;
        secondTimer = 1;

        childTrident = transform.GetChild(0);
        originalPosition = childTrident.position;
        initialRotation = childTrident.rotation;

        rb = childTrident.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onlyOnce && childTrident.gameObject.activeInHierarchy)
        {
            onlyOnce = true;
            rb.isKinematic = false;
            rb.useGravity = true;

            rb.velocity = childTrident.transform.up * (20 + transform.GetComponentInParent<Rigidbody>().velocity.z);

            Debug.Log("me pican los cocos ");
        }

        if (onlyOnce)
        {
            childTrident.transform.up = rb.velocity;

            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            
        }

        if(timer <= 0)
        {
            onlyOnce = false;
            childTrident.gameObject.SetActive(false);

            rb.isKinematic = true;
            childTrident.transform.localPosition = Vector3.zero;
            childTrident.transform.rotation = initialRotation;
            rb.useGravity = false;

            secondTimer -= Time.deltaTime;

            if(secondTimer <= 0)
            {
                timer = 5f;
                secondTimer = 1f;

                childTrident.gameObject.SetActive(true);
            }

        }
        
    }

}
