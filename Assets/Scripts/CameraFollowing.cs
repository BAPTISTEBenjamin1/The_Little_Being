using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] Transform m_cameraTarget;
    [SerializeField] float m_smoothSpeed = 0.125f;
    [SerializeField] Vector3 m_offset;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 desiredPosition = m_cameraTarget.position + m_offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, m_smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = m_cameraTarget.rotation; 

    }
    
}
