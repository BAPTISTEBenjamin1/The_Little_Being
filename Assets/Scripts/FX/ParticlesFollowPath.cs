using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFollowPath : MonoBehaviour
{

[SerializeField] private string m_pathName;
[SerializeField] private float m_time;
    void Start()
    {
        
      Move();

    }

    

    private void Move()
    {

        iTween.MoveTo(gameObject, iTween.Hash("path",iTweenPath.GetPath(m_pathName), "time", 15));


    }


}
