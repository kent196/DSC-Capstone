using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GateSystem : MonoBehaviour
{
    ObeliskController[] obeliskController;
    Animator anim;

    [SerializeField] private bool[] obeliskState;

    public GameObject[] obelisk;

    [SerializeField] private bool allActivated = false;
    // Start is called before the first frame update
    void Start()
    {

        obeliskController = new ObeliskController[obelisk.Length];
        obeliskState = new bool[obelisk.Length];
        for (int i = 0; i < obelisk.Length; i++)
        {
            obeliskController[i] = obelisk[i].GetComponent<ObeliskController>();
        }
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetBool("isActivated", allActivated);
        if (allActivated == false)
        {
            GetObeliskState();
        }
    }


    private void GetObeliskState()
    {
        for (int i = 0; i < obeliskController.Length; i++)
        {
            obeliskState[i] = obeliskController[i].getObeliskState();
        }

        if (obeliskState.All(obe => obe == true))
        {
            allActivated = true;
        }
        else
        {
            Debug.Log("not yet");
        }
    }
}
