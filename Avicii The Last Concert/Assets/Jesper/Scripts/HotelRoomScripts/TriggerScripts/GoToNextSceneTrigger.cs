using System.Collections;
using UnityEngine;

namespace HotelRoomScripts
{
    public class GoToNextSceneTrigger : MonoBehaviour
    {
        private SceneTransitionManager m_SceneTransitionManager;
        [SerializeField]
        private float m_Timer;

        private void Awake()
        {
            m_SceneTransitionManager = GameObject.Find("GameManager").GetComponent<SceneTransitionManager>();
        }

        private void Start()
        {
            if (m_SceneTransitionManager == null)
                Debug.Log("SceneTransitionManager is NULL! " + gameObject.name);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(StartSceneTransitionTimer());
                m_SceneTransitionManager.GoToScene();
            }
        }

        private IEnumerator StartSceneTransitionTimer()
        {
            yield return new WaitForSeconds(m_Timer);
        }
    }
}