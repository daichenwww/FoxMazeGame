using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour
{
    public Camera miniCam;
    public Transform player;
    public Transform miniPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        miniCam.transform.position = new Vector3(player.position.x, miniCam.transform.position.y, player.position.z);
        miniPlayer.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }
}
