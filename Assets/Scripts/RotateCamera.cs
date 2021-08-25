using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Transform m_targetTransform;
    [SerializeField] private Transform m_cameraTransform;
    [SerializeField] private Transform m_CameraPivotTransform;

    private Transform  m_myTransform;
    [SerializeField] Vector3 m_cameraTransformPosition;
    private LayerMask ignoreLayers;

    public static RotateCamera singleton;

    [SerializeField] private float m_lookSpeed = 0.1f;
    [SerializeField] private float m_followSpeed = 0.1f;
    [SerializeField] private float m_pivotSpeed = 0.03f;

    private float m_defaultPosition;
    private float m_lookAnlge;
    private float m_pivotAngle;

    [SerializeField] private float m_minimumPivot = -35;
    [SerializeField] private float m_maximumPivot = 35;

    private void Awake()
    {

        singleton = this;
        m_myTransform = transform;
        m_defaultPosition = m_cameraTransform.localPosition.z;
        ignoreLayers = ~(1 << 8 | 1 << 9| 1 << 10);

    }

    public void FollowTarget (float delta)
    {

        Vector3 targetPosition = Vector3.Lerp(m_myTransform.position, m_targetTransform.position, delta / m_followSpeed);
        m_myTransform.position = targetPosition;


    }

    public void HandleCameraRotation (float delta, float mouseXInput, float mouseYInput)
    {

        m_lookAnlge += (mouseXInput * m_lookSpeed) /delta;
        m_pivotAngle =+ (mouseYInput * m_pivotSpeed) / delta;
        m_pivotAngle = Mathf.Clamp(m_pivotAngle, m_minimumPivot, m_maximumPivot);

        Vector3 rotation = Vector3.zero;

        rotation.y = m_lookAnlge;
        Quaternion m_targetRotation = Quaternion.Euler(rotation);

        m_myTransform.rotation = m_targetRotation;

        rotation = Vector3.zero;
        rotation.x = m_pivotAngle;

        m_targetRotation = Quaternion.Euler(rotation);
        m_CameraPivotTransform.localRotation = m_targetRotation;

    }

}
