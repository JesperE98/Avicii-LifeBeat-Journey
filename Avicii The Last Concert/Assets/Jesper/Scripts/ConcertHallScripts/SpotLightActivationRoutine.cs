using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ConcertHallScripts
{
    public class SpotLightActivationRoutine : AudioManager
    {
        public GameObject[] m_SpotLights;

        public bool m_ConcertTriggerOne = false,
        m_ConcertTriggerTwo = false,
        m_ConcertTriggerThree = false;

        [SerializeField]
        private float m_LightDuration,
            m_SpotlightDeactivationTimerOne,
            m_SpotlightDeactivationTimerTwo,
            m_SpotlightDeactivationTimerThree;

        private BoxCollider concertTriggerTwoCollider;
        private BoxCollider concertTriggerThreeCollider;
        private SceneTransitionManager m_SceneTransitionManager;

        private void Awake()
        {
            foreach (GameObject spotLights in m_SpotLights)
            {
                spotLights.SetActive(false);
            }
           
            concertTriggerTwoCollider = GameObject.Find("ConcertTriggerTwo").GetComponent<BoxCollider>();
            concertTriggerThreeCollider = GameObject.Find("ConcertTriggerThree").GetComponent<BoxCollider>();
            m_SceneTransitionManager = GameObject.Find("GameManager").GetComponent<SceneTransitionManager>();
        }

        void Start()
        {
            //StartCoroutine(SpotLightActivation());

            if (concertTriggerTwoCollider == null)
                Debug.Log("Concert Trigger Two is NULL");


            if (concertTriggerThreeCollider == null)
                Debug.Log("Concert Trigger Two is NULL");

            if (m_SceneTransitionManager == null)
                Debug.Log(gameObject.name + " SceneTransitionManager is NULL!");
            /*
             
            PlayAudioTrack(m_AudioTrackNumber);
            StartCoroutine(SpotLightActivation());
            */
        }

        public void ConcertSetup()
        {

            if (m_ConcertTriggerOne != false && m_ConcertTriggerTwo != true && m_ConcertTriggerThree != true)
            {
                // Spelaren aktivera testet av spotlightsen

                print("One");
                m_SpotLights[8].SetActive(true);
                concertTriggerTwoCollider.enabled = true;
            }

            if (m_ConcertTriggerOne != false && m_ConcertTriggerTwo != false && m_ConcertTriggerThree != true)
            {
                print("Two");
                m_SpotLights[8].SetActive(false);
                m_SpotLights[7].SetActive(true);


                concertTriggerThreeCollider.enabled = true;
            }

            if (m_ConcertTriggerOne != false && m_ConcertTriggerTwo != false && m_ConcertTriggerThree != false)
            {
                // Spelaren startar konsären

                print("Three");
                m_SpotLights[7].SetActive(false);
                PlayAudioTrack(m_AudioTrackNumber);
                StartCoroutine(SpotLightActivation());

            }
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
                    yield return new WaitForSeconds(m_SpotlightDeactivationTimerTwo);
                }
                else if (i == 8)
                {
                    m_SpotLights[i].SetActive(true);
                    yield return new WaitForSeconds(m_SpotlightDeactivationTimerThree);
                    m_SceneTransitionManager.GoToScene();
                }

                m_SpotLights[i].SetActive(true);
                yield return new WaitForSeconds(m_LightDuration);
                m_SpotLights[i].SetActive(false);
            }
        }
    }
}

