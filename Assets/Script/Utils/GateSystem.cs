using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSystem : MonoBehaviour
{
    ObeliskController obeliskController;
    Animator anim;

    [SerializeField] private bool obeliskState = false;
    public GameObject obelisk;
    // Start is called before the first frame update
    void Start()
    {
        obeliskController= obelisk.GetComponent<ObeliskController>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        obeliskState=obeliskController.getObeliskState();
        if (obeliskState==true)
        {
            anim.SetBool("isActivated",true);
        }
    }
}
