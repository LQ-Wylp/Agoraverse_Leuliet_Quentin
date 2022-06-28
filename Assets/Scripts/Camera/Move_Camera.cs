using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour
{
    [Header("Orientation Caméra Horizontale et Verticale")]
    public Transform Camera; // Référence à la camera
    public float Sensitivity; // Sensibilité de la rotation
    public bool InvertY; // Permet d'inversé l'axeY
    public float MyAngle; // Rotation actuelle
    public float MinAngle; // La rotation minimal que peux avoir la camera
    public float MaxAngle; // La Rotation maximal que peux avoir la camera

    // Mouse Value
    public float _MouseX;
    public float _MouseY;

    // Référence au Singleton
    private Edit_Manager MyEM;

    
    void Start()
    {
        MyEM = Edit_Manager._EM;
        if(Camera == null)
        {
            Camera onMe = GetComponentInChildren<Camera>();
            if (onMe != null)
            {
                Camera = onMe.transform;
            }
        }      
    }

    void Update()
    {
        _MouseX = MyEM._MouseX;
        _MouseY = MyEM._MouseY;
        
        // J'applique à ma rotation mon calcule d'angle de rotation
        transform.rotation = Quaternion.AngleAxis(_MouseX * Sensitivity, transform.up) * transform.rotation;

        // Je définis un angle max de vue
        MyAngle = Mathf.Clamp
            (
            MyAngle + _MouseY * Sensitivity * (InvertY ? -1 : 1),
            MinAngle,
            MaxAngle
            );

        Camera.localRotation = Quaternion.AngleAxis(MyAngle , Vector3.right);
    }
}
