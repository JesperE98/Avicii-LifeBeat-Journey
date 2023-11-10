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
    private float m_LightDuration;

    void Start()
    {
        foreach(GameObject spotLights in  m_SpotLights)
        {
            spotLights.SetActive(false);
        }
        StartCoroutine(SpotLightActivation());
    }

    void Update()
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
                yield return new WaitForSeconds(0.45f);
            }
            else if (i == 7)
            {
                m_SpotLights[i].SetActive(true);
                yield return new WaitForSeconds(14.5f);
            }
            else if (i == 8)
            {
                m_SpotLights[i].SetActive(true);
                yield return new WaitForSeconds(45f);
            }

            m_SpotLights[i].SetActive(true);
            yield return new WaitForSeconds(m_LightDuration);
            m_SpotLights[i].SetActive(false);
        }
    }
}
