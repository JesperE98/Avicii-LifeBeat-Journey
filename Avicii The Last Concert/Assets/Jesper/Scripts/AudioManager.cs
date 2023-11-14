using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource[] m_AudioSources;


    private void Awake()
    {
        
    }

    public void PlayAudioTrack(int audioTrackNumber)
    {
        m_AudioSources[audioTrackNumber].Play();
    }
}
