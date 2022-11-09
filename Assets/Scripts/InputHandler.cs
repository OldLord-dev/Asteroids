using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private float flySpeed = 10f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        transform.Translate(horizontalMove * flySpeed * Time.deltaTime, verticalMove * flySpeed * Time.deltaTime, 0);
    }
}
