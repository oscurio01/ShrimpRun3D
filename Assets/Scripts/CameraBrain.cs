using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    public Transform target;

    Vector3 offset;
    public float acceleration = 500;
    [SerializeField] private float pointOfReference;

    Rigidbody rb;

    private void Awake()
    {
        offset = transform.position - target.position;


        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(Vector3.Lerp(transform.position, new Vector3(pointOfReference, target.position.y, target.position.z) + offset, acceleration * Time.deltaTime));
    }
}
