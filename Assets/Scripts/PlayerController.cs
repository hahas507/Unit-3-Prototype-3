using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.AddForce(Vector3.up * 1000);
    }

    private void Update()
    {
    }
}