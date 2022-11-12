using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Speed value between 0 and 30.")]
    private float flySpeed = 10f;
    [SerializeField]
    private GameObject playerShip;
    void Update()
    {
        Move();
        Rotate();
        Fire();
    }
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        playerShip.transform.Translate(horizontalMove * flySpeed * Time.deltaTime, verticalMove * flySpeed * Time.deltaTime, 0,Space.World);
    }
    private void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerShip.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - playerShip.transform.position);
    }
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Pool.singleton.Get("Bullet");
            if (bullet != null)
            {
                bullet.transform.position = playerShip.transform.localPosition;
                bullet.transform.rotation = playerShip.transform.localRotation;
                bullet.SetActive(true);
            }
        }
    }
}
