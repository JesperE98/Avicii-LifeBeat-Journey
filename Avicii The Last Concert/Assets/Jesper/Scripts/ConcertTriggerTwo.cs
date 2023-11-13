using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertTriggerTwo : MonoBehaviour
{
    private SpotLightActivationRoutine m_SpotLightActivationRoutine;

    private void Awake()
    {
        m_SpotLightActivationRoutine = GetComponent<SpotLightActivationRoutine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_SpotLightActivationRoutine.m_ConcertTriggerTwo = true;
            m_SpotLightActivationRoutine.ConcertSetup();
        }
    }
}
