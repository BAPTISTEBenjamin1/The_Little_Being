using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v1 : MonoBehaviour
{
    //[SerializeField][Range (0,1)] private float m_test;
    [SerializeField] private float m_speed = 10;
    [SerializeField] private float m_walkSpeed = 5;
    [SerializeField] private float m_runSpeed = 7;
    [SerializeField] private float m_rotationSpeed = 720;
    
    private float m_x;
    private float m_y;

    private bool m_isMoving;

    Animator m_animator;
    Rigidbody m_rigidbody;
    //[SerializeField] Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.rotation = m_camera.transform.rotation;

        float horizontalInput = Input.GetAxis("LeftJoystickX");
        float verticalInput = Input.GetAxis("LeftJoystickY");

     

        

        Vector3 movementDirection = new Vector3(horizontalInput, 0 ,verticalInput);

        transform.Translate(movementDirection * m_speed * Time.deltaTime, Space.World);

        //Orientation du player en fonction de la direction prise

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, m_rotationSpeed * Time.deltaTime);  
        }   

        m_x = verticalInput;
        m_y = horizontalInput;

        m_animator.SetFloat("x", m_x);
        m_animator.SetFloat("y", m_y);

        if(verticalInput == 0 && horizontalInput == 0)

        {
            m_isMoving = false;
            Debug.Log(m_isMoving);
            m_animator.SetBool("isMoving", false);
        }

        if(verticalInput != 0 && horizontalInput != 0)

        {
             m_isMoving = true;
            Debug.Log(m_isMoving);
            m_animator.SetBool("isMoving", true);
        }

        if(verticalInput >  0.8 || verticalInput < -0.8 || horizontalInput > 0.8 || horizontalInput < -0.8)
        {
            m_speed = Mathf.Lerp(m_speed, m_runSpeed, Time.deltaTime * 2);
        }else
        {
            m_speed = m_walkSpeed;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(verticalInput);
        }
    }
}
