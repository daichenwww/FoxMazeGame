using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    GameObject mon;
    
    float rotateLerpTime;
    Quaternion rotateStart, rotateTarget;

    // Start is called before the first frame update
    void Start()
    {
        mon = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime;

        if (!Mathf.Approximately(transform.localRotation.eulerAngles.y, rotateTarget.eulerAngles.y))
        {
            rotateLerpTime = Mathf.Clamp(rotateLerpTime + Time.deltaTime, 0f, 1f);
            transform.localRotation = Quaternion.Slerp(rotateStart, rotateTarget, rotateLerpTime);
        }
    }
    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.name.Contains("tree") || other.gameObject.name.Contains("Mark"))
        {
            rotateLerpTime = 0;
            rotateStart = transform.localRotation;
            rotateTarget = Quaternion.Euler(transform.localRotation.eulerAngles.x, 
                                            transform.localRotation.eulerAngles.y + (Random.Range(0,2) == 0 ? 90 : -90),
                                            transform.localRotation.eulerAngles.z);    

        }
    }

}
