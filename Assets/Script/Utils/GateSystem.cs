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

    
    private BoxCollider[] colliders;
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
        colliders = GetComponents<BoxCollider>();
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

    void Update()
    {
        float animatorState = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

        // Enable colliders when the door is open
        if (animatorState > 0.99f)
        {
            foreach (BoxCollider collider in colliders)
            {
                collider.enabled = false;
            }
        }
        // Disable colliders when the door is closed
        else
        {
            foreach (BoxCollider collider in colliders)
            {
                collider.enabled = true;
            }
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
    }
}