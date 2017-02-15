using UnityEngine;
using System.Collections;

public class GravityApplier : MonoBehaviour {
    
    [HideInInspector] public Rigidbody rb;
    private float _gravity = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdateByManager()
    {
        rb.AddForce(transform.forward * _gravity);
    }
}
