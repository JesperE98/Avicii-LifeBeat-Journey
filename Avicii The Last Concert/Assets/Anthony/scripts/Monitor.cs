using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{

    private BlinkingAndDestroy _ButtonDestroyed;


    [SerializeField] GameObject phone;


    [SerializeField] GameObject button_1;
    [SerializeField] GameObject button_2;
    [SerializeField] GameObject button_3;
    [SerializeField] bool Isdestroyed1;
    [SerializeField] bool Isdestroyed2;
    [SerializeField] bool Isdestroyed3;
    [SerializeField] private bool _phoneCalling;
    private AudioSource audioSource;
    private void Start()
    {
        _ButtonDestroyed = GetComponent<BlinkingAndDestroy>();
        audioSource = GameObject.Find("phone").GetComponent<AudioSource>();
        
    }
    void Update()
    {
        // Uppdatera variablerna baserat p� om objekten �r f�rst�rda eller inte
        Isdestroyed1 = IsObjectDestroyed(button_1);
        Isdestroyed2 = IsObjectDestroyed(button_2);
        Isdestroyed3 = IsObjectDestroyed(button_3);
        

        // Kolla om alla objekt �r f�rst�rda
        if ( Isdestroyed1 && Isdestroyed2 && Isdestroyed3 && _phoneCalling == false)
        {
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("telefonen ringer");
                _phoneCalling = true;
            }
        }
        
    }

    // Metod f�r att kontrollera om ett objekt �r f�rst�rt eller null
    bool IsObjectDestroyed(GameObject obj)
    {
        return obj == null || !obj.activeInHierarchy;
    }

    // �vrig kod...
}
