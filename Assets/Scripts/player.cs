using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController2D CController;
    public float player_speed = 40f;
    float horizontalMove = 0f;
    public bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * player_speed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        CController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
