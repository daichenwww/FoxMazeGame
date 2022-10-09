using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour
{
    GameObject fox;
    public GameObject chick;
    private int chickNumber = 0;
    private Vector3 pos;

    
    // Start is called before the first frame update
    void Start()
    {
        fox = gameObject;
        chickNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Contains("Chick") & chickNumber < 3) {
            Destroy(other.gameObject);
            chickNumber = chickNumber + 1;
            var newChick = Instantiate(chick, transform.position , Quaternion.identity);
            newChick.transform.parent = fox.transform;
            newChick.transform.localPosition = new Vector3(-2+chickNumber, 0.8f + (chickNumber+1)%2, -0.5F);
            newChick.transform.localScale = new Vector3(2, 2, 2);
        }
    }
}
