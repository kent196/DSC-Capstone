using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Other's Component
    private Transform playerTransform;

    //Parameter
    [SerializeField] private Vector3 offSet;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offSet;
    }
}
