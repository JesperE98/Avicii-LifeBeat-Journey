using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightActivationRoutine : MonoBehaviour
{
    // SpotLightsen ska aktiveras efter x antal sekunder
    // Lägga in alla SpotLights gameObjekt i en Array

    [SerializeField]
    private GameObject[] m_SpotLights;
    [SerializeField]
    private float m_LightDuration, m_SpotlightDeactivationTimerOne, m_SpotlightDeactivationTimerTwo, m_SpotlightDeactivationTimerThree;

    public bool m_ConcertTriggerOne = false, m_ConcertTriggerTwo = false, m_ConcertTriggerThree = false;

    void Start()
    {
        foreach(GameObject spotLights in  m_SpotLights)
        {
            spotLights.SetActive(false);
        }
    }

    void Update()
    {
        if (m_ConcertTriggerOne != false)
        {
            // Spelaren aktivera testet av spotlightsen
        }
        else if (m_ConcertTriggerOne != false && m_ConcertTriggerTwo != false)
        {
            // Spelare testar musiken så att den spelas upp
        }
        else if (m_ConcertTriggerOne != false && m_ConcertTriggerTwo != false && m_ConcertTriggerThree != false)
        {
            // Spelaren startar konsären
            StartCoroutine(SpotLightActivation());
        }
    }

    public void ConcertSetup()
    {

    }

    // Denna rutin ska triggas igång med hjälp av en Trigger senare
    public IEnumerator SpotLightActivation()
    {
        for (int i = 0; i < m_SpotLights.Length; i++)
        {
            print(i);
            

            if (i == 6)
            {
                m_SpotLights[i].SetActive(true);
                yield return new WaitForSeconds(m_SpotlightDeactivationTimerOne);
            }
            else if (i == 7)
            {
                m_SpotLights[i].SetActive(true);
                yield return new WaitForSeconds(m_SpotlightDeactivationTimerOne);
            }
            else if (i == 8)
            {
                m_SpotLights[i].SetActive(true);
                yield return new WaitForSeconds(m_SpotlightDeactivationTimerThree);
            }

            m_SpotLights[i].SetActive(true);
            yield return new WaitForSeconds(m_LightDuration);
            m_SpotLights[i].SetActive(false);
        }
    }
}
