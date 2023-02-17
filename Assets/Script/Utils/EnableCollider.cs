using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider : MonoBehaviour
{
    [SerializeField] private GameObject theObject;
    private Animator theObjectAnimator;
    private Collider2D theObjectCollider;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 32; i++)
        {
            if(i != 10)
            {
                Physics2D.IgnoreLayerCollision(19, i, true);
            }
        }
        theObjectAnimator = theObject.GetComponent<Animator>();
        theObjectCollider = theObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(theObject == null)
        {
            return;
        }

        Destroy(gameObject);
        theObjectAnimator.SetTrigger("close");
    }

    
}
