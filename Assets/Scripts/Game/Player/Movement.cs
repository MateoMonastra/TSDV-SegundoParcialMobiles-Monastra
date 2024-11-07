using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Action OnMove;

    [SerializeField] private float fowardSpeed;
    [SerializeField] private float sideSpeed;

    private Rigidbody rb;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isDead) return;
        rb.velocity = transform.forward * (fowardSpeed * Time.deltaTime);
        OnMove?.Invoke();
    }
}