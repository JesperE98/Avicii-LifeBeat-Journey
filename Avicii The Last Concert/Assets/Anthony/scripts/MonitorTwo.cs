using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorTwo : SceneTransitionManager
{
    [SerializeField]
    private float m_Countdown;

    [SerializeField]
    private bool m_CountdownDone;

    public void StartRoutine()
    {
        StartCoroutine(CountdownToLoadNextScene());
    }
    void Update()
    {
        // Kolla om alla objekt är förstörda
        if (m_CountdownDone != false)
        {
            GoToScene();
        }
        m_CountdownDone = false;
    }

    // Metod för att kontrollera om ett objekt är förstört eller null
    private IEnumerator CountdownToLoadNextScene()
    {
        yield return new WaitForSeconds(m_Countdown);
        m_CountdownDone = true;
    }
}
