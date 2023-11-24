using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is null!!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }


    [SerializeField]
    protected AudioSource[] m_AudioSources;
    [SerializeField]
    protected int m_AudioTrackNumber;

    public void PlayAudioTrack(int audioTrackNumber)
    {       
        m_AudioSources[audioTrackNumber].Play();
    }

    public void StopAudioTrack(int audioTrackNumber)
    {
        m_AudioSources[audioTrackNumber].Stop();
    }
}
