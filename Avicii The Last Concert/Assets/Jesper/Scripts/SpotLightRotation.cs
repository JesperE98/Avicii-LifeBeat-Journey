using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightRotation : MonoBehaviour
{

    // SpotLightsen ska röra sig diskret åt en riktning när dem aktivers

    private Transform m_StartPosition;

    [SerializeField]
    private float m_DesiredDuration = 1.0f;
    private float m_ElapsedTime;


    void Start()
    {
        m_StartPosition = gameObject.transform;
    }


    void Update()
    {
        SpotLightMovement();
    }

    private void SpotLightMovement()
    {
        m_ElapsedTime += Time.deltaTime;
        float percentageComplete = m_ElapsedTime / m_DesiredDuration;

        transform.rotation = Quaternion.Lerp(m_StartPosition.rotation, Quaternion.Euler(1f, 0f, 1f), percentageComplete);
    }
}
