using System.Collections;
using UnityEngine;

public class GoToNextSceneTrigger : SceneTransitionManager
{
    [SerializeField]
    private int m_Timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StartSceneTransitionTimer());
            GoToScene();
        }
    }

    private IEnumerator StartSceneTransitionTimer()
    {
        yield return new WaitForSeconds(m_Timer);
    }
}