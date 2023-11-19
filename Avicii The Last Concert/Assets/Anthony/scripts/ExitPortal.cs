using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [Range(0, 10)]
    public float scale;
    public float sparkSpinSpeed, ringSpinSpeed, scaleSpeed;
    public int sparkAmount;
    public GameObject sparkFX;

    private Transform sparkSpinControl, ringSpinControl;

    void Start()
    {
        sparkSpinControl = transform.Find("SparkSpinControl");
        ringSpinControl = transform.Find("RingSpinControl");

        CreateSparksAroundPoint();
    }

 
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale, scale, scale), scaleSpeed * Time.deltaTime);
        sparkSpinControl.Rotate(transform.forward, sparkSpinSpeed * Time.deltaTime);
       
    }

    void CreateSparksAroundPoint()
    {
        for (int i = 0; i < sparkAmount; i++)
        {
            var radians = 2 * Mathf.PI / sparkAmount * i;

            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector3(horizontal, vertical, 0);

            var spawnPos = transform.position + spawnDir;

            var enemy = Instantiate(sparkFX, sparkSpinControl);

            enemy.transform.position = spawnPos;

            Vector3 relativePos = enemy.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);

            enemy.transform.rotation = rotation;
        }
    }
}
