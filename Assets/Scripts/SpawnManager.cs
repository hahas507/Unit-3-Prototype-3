using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private void Start()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}