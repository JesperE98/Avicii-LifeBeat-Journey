using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertTrigger : MonoBehaviour
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
            Debug.Log("Actiavted routine one");
            m_SpotLightActivationRoutine.m_ConcertTriggerOne = true;
            m_SpotLightActivationRoutine.ConcertSetup();
        }
    }
}
