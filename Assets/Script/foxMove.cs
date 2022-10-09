using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxMove : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float rotateSpeed = 1.8f;
    public float jumpSpeed = 10.0f;
    GameObject fox; 
    private bool onGround = true;
    private bool flying = false;
    private bool canFly = true;
    private float coldTime_fly = 10.0f;
    private float timer_fly = 0.0f;
    
    private bool WPress = false;
    private bool APress = false;
    private bool SPress = false;
    private bool DPress = false;
    private bool SpacePress = false;

    

    // Start is called before the first frame update
    void Start()
    {
        fox = gameObject;
        fox.GetComponent<Rigidbody>().freezeRotation = true;

        onGround = true;
        flying = false;
        canFly = true;


    }
    private void FixedUpdate() {
        Move();
    }
    
    // Update is called once per frame
    void Update()
    { 
        if (!canFly) {
            print("Time: " + timer_fly);
            print(flying);
            timer_fly += Time.deltaTime;
            if (timer_fly > 5f & flying) {
                fox.GetComponent<Rigidbody>().AddForce(0, -10000f, 0);
            }
            if (timer_fly >= coldTime_fly) {
                timer_fly = 0;
                canFly = true;
            }
        }

        WPress = Input.GetKey(KeyCode.W);
        APress = Input.GetKey(KeyCode.A);
        SPress = Input.GetKey(KeyCode.S);
        DPress = Input.GetKey(KeyCode.D);
        SpacePress = Input.GetKeyDown(KeyCode.Space);

        

    }
    void OnTriggerEnter(Collider other) {
        print(other.gameObject.name);
        if (other.gameObject.name == "trigger") {
            if (canFly){
                flying = true;
                canFly = false;
                onGround = false;
                fox.GetComponentInChildren<Animator>().SetInteger("fly", 1);
                print("FLYING!!! flying = " + flying);
                Invoke("Fly", 0.5f);
            }

        }
    }
    private void OnCollisionEnter(Collision other) {
        print(other.gameObject.name);
        if (flying & timer_fly > 2f) {
            flying = false;
        }
        if (other.gameObject.name.Contains("Floor") || other.gameObject.name.Contains("trigger") || other.gameObject.name.Contains("Mark")){
            onGround = true;
        }
        
        
    }
    void Move() {
        if (onGround) fox.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        else fox.GetComponent<Rigidbody>().AddForce(0, -1000f, 0);

        fox.GetComponentInChildren<Animator>().SetInteger("walking", 0);
        fox.GetComponentInChildren<Animator>().SetInteger("jumping", 0);
        fox.GetComponentInChildren<Animator>().SetInteger("turnLeft", 0);
        fox.GetComponentInChildren<Animator>().SetInteger("turnRight", 0);

        if (!flying) {
            if (WPress) {
                fox.GetComponent<Rigidbody>().velocity += transform.forward * moveSpeed;
                fox.GetComponentInChildren<Animator>().SetInteger("walking", 1);
            }
            else if (SPress) {
                fox.GetComponent<Rigidbody>().velocity += -transform.forward * moveSpeed * 0.7f;
                fox.GetComponentInChildren<Animator>().SetInteger("walking", -1);
            }
            if (SpacePress) {
                print("onGroung = " + onGround);
                if (onGround) {
                    onGround = false;
                    fox.GetComponentInChildren<Animator>().SetInteger("jumping", 1);
                    Invoke("Jump", 0.5f);

                }
            }
        }
        
        if (APress) {
            fox.transform.Rotate(0, -rotateSpeed, 0);
            fox.GetComponentInChildren<Animator>().SetInteger("turnLeft", 1);
        }
        if (DPress) {
            fox.transform.Rotate(0, rotateSpeed, 0);
            fox.GetComponentInChildren<Animator>().SetInteger("turnRight", 1);
        }
        
        

    }
    void Jump(){
        fox.GetComponent<Rigidbody>().AddForce(transform.up * 30000f);
    }
    void Fly(){
        fox.GetComponent<Rigidbody>().AddForce(transform.up * 300000f);
        fox.GetComponentInChildren<Animator>().SetInteger("fly", 0);
    }
}
