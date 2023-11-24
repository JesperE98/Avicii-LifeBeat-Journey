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
        // Kolla om alla objekt �r f�rst�rda
        if (m_CountdownDone != false)
        {
            GoToScene();
        }
        m_CountdownDone = false;
    }

    // Metod f�r att kontrollera om ett objekt �r f�rst�rt eller null
    private IEnumerator CountdownToLoadNextScene()
    {
        yield return new WaitForSeconds(m_Countdown);
        m_CountdownDone = true;
    }
}
