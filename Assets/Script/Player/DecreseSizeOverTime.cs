using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreseSizeOverTime : MonoBehaviour
{
    private Transform thisTransform;
    [SerializeField] float decreaseSizeSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float scaleX = transform.localScale.x;
        float scaleY = transform.localScale.y;

        scaleX -= Time.deltaTime* 1/decreaseSizeSpeed;
        scaleY -= Time.deltaTime* 1/decreaseSizeSpeed;

        transform.localScale = new Vector3(scaleX,scaleY,1);



    }
}
