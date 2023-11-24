using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirportScripts
{
    public class AnnouncementTrigger : AudioManager
    {
        private BoxCollider m_BoxCollider;

        private void Awake()
        {
            m_BoxCollider = this.GetComponent<BoxCollider>();
        }

        private void Start()
        {
            if (m_BoxCollider == null)
                Debug.Log(this.gameObject.name + " BoxCollider is NULL!!");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_BoxCollider.enabled = false;
                PlayAudioTrack(m_AudioTrackNumber);
            }
        }
    }
}

