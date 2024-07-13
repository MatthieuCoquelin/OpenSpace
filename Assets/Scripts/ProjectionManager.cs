using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionManager : MonoBehaviour
{
    [SerializeField] private Transform m_transformTarget = null;
    [SerializeField] private float m_raycasDistance = 2f;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private float m_radius = 0.05f;
    [SerializeField] private float m_offset = 0.02f;


    // Update is called once per frame
    void Update()
    {
        if (!m_transformTarget)
            return;

        RaycastHit raycastHit;
        Physics.SphereCast(m_transformTarget.position, m_radius, Vector3.down, out raycastHit, m_raycasDistance, m_layerMask);
        transform.position = new Vector3(m_transformTarget.position.x, raycastHit.point.y + m_offset, m_transformTarget.position.z);
    }
}
