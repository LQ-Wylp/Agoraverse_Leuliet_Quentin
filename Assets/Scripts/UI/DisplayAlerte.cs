using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAlerte : MonoBehaviour
{
    // Ce script sert à activé un gameobject durant un laps de temps définis.
    public GameObject AlerteObject;
    public float DurationAlerte;
    private float RemainingTime;
    
    void Update()
    {
        RemainingTime -= Time.deltaTime;

        if(RemainingTime <= 0)
        {
            AlerteObject.gameObject.SetActive(false);
        }
    }

    public void ShowAlerte()
    {
        RemainingTime = DurationAlerte;
        AlerteObject.gameObject.SetActive(true);
    }
}
