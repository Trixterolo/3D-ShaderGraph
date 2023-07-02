using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public float circleClipStart;
    public float featherStart;
    public float ringWidthStart;
    public float portalSpeed;

    private float circleClipTarget;
    private float featherTarget;
    private float ringWidthTarget;

    private float circleClipCurrent;
    private float featherCurrent;
    private float ringWidthCurrent;

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        circleClipCurrent = Mathf.Lerp(circleClipCurrent, circleClipTarget, Time.deltaTime * portalSpeed);
        featherCurrent = Mathf.Lerp(featherCurrent, featherTarget, Time.deltaTime * portalSpeed);
        ringWidthCurrent = Mathf.Lerp(ringWidthCurrent, ringWidthTarget, Time.deltaTime * portalSpeed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            circleClipTarget = circleClipStart;
            featherTarget = featherStart;
            ringWidthTarget = ringWidthStart;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            circleClipTarget = 0;
            featherTarget = 0;
            ringWidthTarget = 0;
        }

        //update values in shaderGraph -> leading to Lerp above repeating but with potential new values.
        mat.SetFloat("_CircleClip", circleClipCurrent);
        mat.SetFloat("_Feather", featherCurrent);
        mat.SetFloat("_RingWidth", ringWidthCurrent);
    }
}
