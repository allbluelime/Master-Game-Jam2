using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimation;
    [SerializeField]
    private CurrentState playerState;
    private Rigidbody rbody;
    private Camera viewCamera;
    private Vector3 velocity;
    [SerializeField]
    private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        AnimationChecker();
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);
       if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerState = CurrentState.Walking;
        }
        else
        {
            playerState = CurrentState.Idle;
        }
    }
    private void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + velocity * Time.fixedDeltaTime);
    }

    private void AnimationChecker()
    {
        if (playerState == CurrentState.Idle)
        {
            playerAnimation.SetBool("isWalking", false);
        }
        else if (playerState == CurrentState.Walking)
        {
            playerAnimation.SetBool("isWalking", true);
        }
    }
    enum CurrentState
    {
        Idle,
        Walking

    }
}
