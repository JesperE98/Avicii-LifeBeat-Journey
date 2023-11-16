using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField]
    protected AudioSource[] m_AudioSources;
    [SerializeField]
    protected int m_AudioTrackNumber;

    private void Awake()
    {
        
    }

    public void PlayAudioTrack(int audioTrackNumber)
    {       
        m_AudioSources[audioTrackNumber].Play();
    }

    public void StopAudioTrack(int audioTrackNumber)
    {
        m_AudioSources[audioTrackNumber].Stop();
    }
}
