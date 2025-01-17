using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float fastSpeed = 25f;
    [SerializeField] float normalSpeed = 10f;
    Rigidbody2D rb2d; //variables must be member variables if you want to access them in multiple places
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls(){
        canMove = false;
    }
    
    void RotatePlayer() {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost() {
        if(Input.GetKey(KeyCode.DownArrow)) {
            //speed up
            surfaceEffector2D.speed = fastSpeed;
        }
        else {
            //normal speed
            surfaceEffector2D.speed = normalSpeed;
        }
    }
}
