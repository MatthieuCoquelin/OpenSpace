using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_ballPrefab = null;
    private float spawnSpeed = 5;

    [Header("Controllers")]
    [SerializeField] private Transform m_leftControllerTransform = null;
    [SerializeField] private Transform m_rightControllerTransform = null;

    [Header("Hands")]
    [SerializeField] private Transform m_leftHandTransform = null;
    [SerializeField] private Transform m_rightHandTransform = null;
    [SerializeField] private float m_timeBetweenInstances = 0.25f;

    private bool m_isLeftHandUp;
    private bool m_isRightHandUp;

    // Start is called before the first frame update
    void Start()
    {
        m_isLeftHandUp = false;
        m_isRightHandUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_ballPrefab)
            return;

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            GameObject spawnedBall = Instantiate(m_ballPrefab, m_rightControllerTransform.position, Quaternion.identity);
            Rigidbody ballRigidbody = spawnedBall.transform.GetChild(0).GetComponent<Rigidbody>();
            ballRigidbody.velocity = m_rightControllerTransform.forward * spawnSpeed;
            Destroy(spawnedBall, 10f);
        }
        else  if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            GameObject spawnedBall = Instantiate(m_ballPrefab, m_leftControllerTransform.position, Quaternion.identity);
            Rigidbody ballRigidbody = spawnedBall.transform.GetChild(0).GetComponent<Rigidbody>();
            ballRigidbody.velocity = m_leftControllerTransform.forward * spawnSpeed;
            Destroy(spawnedBall, 10f);
        }
    }

    public void SetLeftHandUp()
    {
        m_isLeftHandUp = true;
        StartCoroutine(BallInstantiationLeftCoroutine());
    }

    public void SetRightHandUp()
    {
        m_isRightHandUp = true;
        StartCoroutine(BallInstantiationRightCoroutine());
    }
    
    IEnumerator BallInstantiationLeftCoroutine()
    {
        while(m_isLeftHandUp)
        {
            GameObject spawnedBall = Instantiate(m_ballPrefab, m_leftHandTransform.position, Quaternion.identity);
            Rigidbody ballRigidbody = spawnedBall.transform.GetChild(0).GetComponent<Rigidbody>();
            ballRigidbody.velocity = m_leftHandTransform.forward * spawnSpeed;
            Destroy(spawnedBall, 10f);
            yield return new WaitForSeconds(m_timeBetweenInstances);
        }
    }
    
    IEnumerator BallInstantiationRightCoroutine()
    {
        while(m_isRightHandUp)
        {
            GameObject spawnedBall = Instantiate(m_ballPrefab, m_rightHandTransform.position, Quaternion.identity);
            Rigidbody ballRigidbody = spawnedBall.transform.GetChild(0).GetComponent<Rigidbody>();
            ballRigidbody.velocity = m_rightHandTransform.forward * spawnSpeed;
            Destroy(spawnedBall, 10f);
            yield return new WaitForSeconds(m_timeBetweenInstances);
        }
    }

    public void SetLeftHandDown()
    {
        m_isLeftHandUp = false;
        StopCoroutine(BallInstantiationLeftCoroutine());
    }
    public void SetRightHandDown()
    {
        m_isRightHandUp = false;
        StopCoroutine(BallInstantiationRightCoroutine());
    }
}
