using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Transform m_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_player.transform.rotation = transform.rotation;

        float horizontalInput = Input.GetAxis("RightJoystickX");
        float verticalInput = Input.GetAxis("RightJoystickY");

        if(verticalInput < 0)
        {
            //Transform.Rotate(Vector3.forward * verticalInput * Time.deltaTime);
            Debug.Log("Tu montes");

        }

        if(verticalInput > 0)
        {

            Debug.Log("Tu Descends");

        }

    }
}
