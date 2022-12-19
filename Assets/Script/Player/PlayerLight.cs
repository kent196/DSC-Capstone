using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D playerLight;

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLight.pointLightOuterRadius -= Time.deltaTime * 0.1f;
    }
}
