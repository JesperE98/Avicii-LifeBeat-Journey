using UnityEngine;

namespace HotelRoomScripts
{
    public class StartPhoneSoundTrigger : AudioManager
    {
        private BoxCollider m_BoxCollider;

        private void Awake()
        {
            m_BoxCollider = GetComponent<BoxCollider>();
        }
        private void Start()
        {
            if (m_BoxCollider == null)
                Debug.Log("BoxCollider is null " + gameObject.name);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                m_BoxCollider.enabled = false;
                PlayAudioTrack(m_AudioTrackNumber);
            }
        }
    }
}

