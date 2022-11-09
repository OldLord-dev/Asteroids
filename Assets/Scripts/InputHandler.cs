using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private float flySpeed = 10f;
    [SerializeField]
    private GameObject shipSprite;
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        transform.Translate(horizontalMove * flySpeed * Time.deltaTime, verticalMove * flySpeed * Time.deltaTime, 0);
    }

    private void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shipSprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
