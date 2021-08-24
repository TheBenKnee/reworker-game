using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float rippleWaitMin = 2f;
    [SerializeField] private float rippleWaitMax = 4f;
    [SerializeField] private float rippleLength = 1.16f;
    private float rippleTime;
    private AnimatorController myAnim;
    private bool isWater = true;
    private bool needsChange = true;

    void Start()
    {
        myAnim = gameObject.GetComponent(typeof(AnimatorController)) as AnimatorController;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(needsChange)
        {
            rippleTime = rippleLength;
            isWater = false;
            myAnim.SetAnimParameter("state", false);
            needsChange = false;
        }
        if(isWater && rippleTime < 0f)
        {
            needsChange = true;
        }
        if(!isWater && rippleTime < 0f)
        {
            isWater = true;
            myAnim.SetAnimParameter("state", true);
            rippleTime = Random.Range(rippleWaitMin, rippleWaitMax);
        }
        rippleTime -= Time.deltaTime;
    }

}
