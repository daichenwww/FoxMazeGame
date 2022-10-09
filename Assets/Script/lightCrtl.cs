using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCrtl : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotateSpeed, 0, 0);
    }
}
