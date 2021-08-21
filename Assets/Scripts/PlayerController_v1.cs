using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v1 : MonoBehaviour
{
    [SerializeField] private float m_speed = 10;
    [SerializeField] private float m_walkSpeed = 5;
    [SerializeField] private float m_runSpeed = 7;
    [SerializeField] private float m_rotationSpeed = 720;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        float horizontalInput = Input.GetAxis("LeftJoystickX");
        float verticalInput = Input.GetAxis("LeftJoystickY");
 /*    
        transform.Translate(Vector3.right * m_speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.back * m_speed * verticalInput * Time.deltaTime);
*/
        Vector3 movementDirection = new Vector3 (horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * m_speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, m_rotationSpeed * Time.deltaTime);  

        }   
        

        if(verticalInput >  0.5 || verticalInput < -0.5 || horizontalInput > 0.5 || horizontalInput < -0.5)
        {

            m_speed = m_runSpeed;

        }else
        {
            m_speed = m_walkSpeed;
        }
    }
}
