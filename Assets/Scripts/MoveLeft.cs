using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}