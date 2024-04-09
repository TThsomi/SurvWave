using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody _rigidbody;
    public float speed = 2f;
    public float rotationspeed = 10f;
    public FixedJoystick joystick;
    public float horizontal;
    public float vertical;
    public float lerpMultiplier = 7f;
    public float JumpForce = 3f;
    public Transform groundcheckerTransorm;
    public LayerMask notPlayerMask;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Mathf.Lerp(horizontal, joystick.Horizontal, Time.deltaTime * lerpMultiplier);
        vertical = Mathf.Lerp(vertical, joystick.Vertical, Time.deltaTime * lerpMultiplier);
        
        float h = horizontal;
        float v = vertical;

        Vector3 directionVector = new Vector3(-v, 0, h);
        if(directionVector.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationspeed);

        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, 1) * speed;
        _rigidbody.velocity = new Vector3(moveDir.x, _rigidbody.velocity.y, moveDir.z);
        _rigidbody.angularVelocity = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //JumpPlayer();
            animator.SetTrigger("jump");
        }

        if (Physics.Raycast(groundcheckerTransorm.position, Vector3.down, 0.2f, notPlayerMask))
        {
            animator.SetBool("isinAir", false);
        }
        else
        {
            animator.SetBool("isinAir", true);
        }
    }

    public void JumpPlayer()
    {
        //if (Physics.Raycast(groundcheckerTransorm.position, Vector3.down, 0.2f, notPlayerMask))
        //{
        //    animator.SetTrigger("jump");

        //    _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        //}
        animator.SetTrigger("Jump");
    }

    public void JumpButton()
    {
        animator.SetTrigger("jump");
        JumpPlayer();
    }
}
