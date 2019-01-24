using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private PlayerMovement1 playerMovement;

    // Start is called before the first frame update
    private float horizontalMovement;
    private bool jump;
    private bool run;
    private bool facingRight;
    private float lastTapLeftTime;
    private float lastTapRightTime;
    [SerializeField] private float tapSpeed = 0.2f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement1>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (horizontalMovement > 0f)
        {
            facingRight = true;
            OnFacingChange();
        }
        else if (horizontalMovement < 0f)
        {
            facingRight = false;
            OnFacingChange();
        }
        if (horizontalMovement < -Mathf.Epsilon)
        {
            if (Time.time - lastTapLeftTime < tapSpeed)
            {
                run = true;
            }
            lastTapLeftTime = Time.time;
        }
        if (horizontalMovement > Mathf.Epsilon)
        {
            if (Time.time - lastTapRightTime < tapSpeed)
            {
                run = true;
            }
            lastTapRightTime = Time.time;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void OnFacingChange()
    {
        if (!facingRight)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1,1,1);            
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move(horizontalMovement, jump,run);
        if (jump)
            jump = false;
    }
}