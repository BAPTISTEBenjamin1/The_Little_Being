using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] Transform m_player;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       Vector3 direction = player.position - transform.position;
       float angle = Mathf.Atan3(direction.y, direction.x, direction.z);

    }
}
