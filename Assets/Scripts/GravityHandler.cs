using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class GravityHandler : MonoBehaviour
{
    private Rigidbody m_rigidbody = null;
    [SerializeField] private GameObject m_shadow = null;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsPositionInRoom();
    }

    public void IsPositionInRoom()
    {
        if (!m_rigidbody)
            return;

        var isInRoom = MRUK.Instance?.GetCurrentRoom()?.IsPositionInRoom(transform.position);

        if (isInRoom.HasValue && isInRoom.Value)
        {
            m_rigidbody.useGravity = true;
            m_shadow.SetActive(true);
        }
        else
        {
            m_rigidbody.useGravity = false;
            m_shadow.SetActive(false);
        }
    }
}
