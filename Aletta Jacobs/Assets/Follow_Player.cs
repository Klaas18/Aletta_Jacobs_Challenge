using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
   [SerializeField] Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, 0);
    }
}
