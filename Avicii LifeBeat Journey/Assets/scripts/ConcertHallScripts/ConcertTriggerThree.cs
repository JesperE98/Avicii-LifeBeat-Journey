using UnityEngine;

namespace ConcertHallScripts
{
    public class ConcertTriggerThree : MonoBehaviour
    {
        private SpotLightActivationRoutine m_SpotLightActivationRoutine;

        private void Start()
        {
            m_SpotLightActivationRoutine = GameObject.Find("LightShow").GetComponent<SpotLightActivationRoutine>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_SpotLightActivationRoutine.m_ConcertTriggerThree = true;
                m_SpotLightActivationRoutine.ConcertSetup();
            }
        }
    }
}

