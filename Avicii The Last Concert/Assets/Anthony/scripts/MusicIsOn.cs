using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIsOn : MonoBehaviour
{
    public bool _objectIsActive;
    [SerializeField] GameObject music;


    void Start()
    {
        if (gameObject.activeSelf)
        {

        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
