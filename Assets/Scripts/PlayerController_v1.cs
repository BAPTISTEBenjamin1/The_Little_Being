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
    [SerializeField] private float m_cameraTurnSpeed;
    
    private float m_x;
    private float m_y;

    private bool m_isMoving;

    Animator m_animator;
    RotateCamera m_rotateCamera;
    //[SerializeField] Camera m_camera;
    // Start is called before the first frame update
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rotateCamera = RotateCamera.singleton;
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        // transform.rotation = m_camera.transform.rotation;

        float horizontalInput = Input.GetAxis("LeftJoystickX");
        float verticalInput = Input.GetAxis("LeftJoystickY");
        float RverticalInput = Input.GetAxis("RightJoystickY");
        float RhorizontalInput = Input.GetAxis("RightJoystickX");
 /*    
        transform.Translate(Vector3.right * m_speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.back * m_speed * verticalInput * Time.deltaTime);
*/
        Vector3 movementDirection = new Vector3 (horizontalInput, 0, verticalInput);
        //movementDirection.Normalize();

        transform.Translate(movementDirection * m_speed * Time.deltaTime, Space.World);
         Vector3 relative;
        relative = transform.InverseTransformDirection(Vector3.up);
               
        //Orientation du player en fonction de la direction prise

        if(movementDirection != Vector3.zero)
        {

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, m_rotationSpeed * Time.deltaTime);  

        }   

         if(m_rotateCamera != null)
            {

                m_rotateCamera.FollowTarget(delta);
                m_rotateCamera.HandleCameraRotation(delta, RhorizontalInput, RverticalInput);

            }

        m_x = verticalInput;
        m_y = horizontalInput;

        m_animator.SetFloat("x", m_x);
        m_animator.SetFloat("y", m_y);

        

        //float input = Mathf.Clamp01(new Vector2(horizontalInput, verticalInput)).magnitute;

        
        
        //m_x = input;
            

        //if(verticalInput < 0 &&)

        if(verticalInput == 0 && horizontalInput == 0)

        {

            //m_speed = 0;
            m_isMoving = false;
            Debug.Log(m_isMoving);
            m_animator.SetBool("isMoving", false);


        }

        if(verticalInput != 0 && horizontalInput != 0)

        {

           // m_speed = 0;
             m_isMoving = true;
            Debug.Log(m_isMoving);
            m_animator.SetBool("isMoving", true);


        }

        if(verticalInput >  0.8 || verticalInput < -0.8 || horizontalInput > 0.8 || horizontalInput < -0.8)
        {
           
            //m_isMoving = true;
            //Debug.Log(m_isMoving);
            //m_animator.SetBool("isMoving", true);
            m_speed = Mathf.Lerp(m_speed, m_runSpeed, Time.deltaTime * 2);
            
            //m_speed = m_runSpeed;
           // m_animator.SetFloat("x", m_y);
            //m_animator.SetFloat("y", m_x);

                

        }else
        {
            m_speed = m_walkSpeed;
            //m_animator.SetFloat("x", -1);
            //m_animator.SetFloat("y", 0);
        }

       
        if(Input.GetMouseButtonDown(0))
        {

            Debug.Log(verticalInput);

        }
        


        

    }
}
