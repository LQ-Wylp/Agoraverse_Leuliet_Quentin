using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Object : MonoBehaviour
{

    public bool IsSelected = false; // Variable qui donne l'état de selection de l'objet
    public float MoveGap = 1; // Variable déterminant la distance parcourue par l'objet à chaque tic
    private float LastTimeMove; // Stock la date du dernière mouvement
    public float MoveTimeInterval = 0.5f; // Variable définissant l'intervalle de temps entre chaque "MoveGap" en cas de matiens de la touche
    private Edit_Manager MyEM;
    public SwitchMaterial MySM; // Référence au script qui gére les changements de matériaux

    public bool IsMovingMode = false; // Variable qui donne l'info si l'objet est en cours de déplacement à l'instant t
    public bool IsCollided = false; // Variable qui donne l'info si l'objet est en collision à l'instant t

    public float RotateSpeed = 0.1f; // Vitesse de rotation

    void Start()
    {
        MyEM = Edit_Manager._EM;
        LastTimeMove = Time.time - MoveTimeInterval;
    }

    void Update()
    {
        /////////////////////////
        ///// Déplacement //////
        ///////////////////////

        if(!IsSelected) // Si je ne suis pas selectionné je met mon matérial par défault
        {
            MySM.SwitchMyMaterial(1);
            IsMovingMode = false;
        }
        else // Si je suis selectionné je met mon matérial de sélection
        {
            MySM.SwitchMyMaterial(2);
        }


        // Fait bouger l'objet s'il est séléctionné.
        if(IsSelected && MoveTimeInterval + LastTimeMove < Time.time) // Si je suis sélectionné je me déplace en fonction des variable MoveX et MoveY
        {
            bool IsMoved = false;
            float MoveX = MyEM._MoveInput.x;
            float MoveY = MyEM._MoveInput.y;

            if(MoveX > 0)
            {
                gameObject.transform.position += new Vector3(MoveGap,0,0);
                IsMoved = true;
            }
            else if(MoveX < 0)
            {
                gameObject.transform.position -= new Vector3(MoveGap,0,0);
                IsMoved = true;
            }

            if(MoveY > 0)
            {
                gameObject.transform.position += new Vector3(0,0,MoveGap);
                IsMoved = true;
            }
            else if(MoveY < 0)
            {
                gameObject.transform.position -= new Vector3(0,0,MoveGap);
                IsMoved = true;
            }

            if(IsMoved)
            {
                IsMovingMode = true;
                LastTimeMove = Time.time; 
            }
        }

        if(IsMovingMode)
        {
            if(IsCollided) // En cas de collision je change mon matérial
            {
                MySM.SwitchMyMaterial(4);
                MyEM.CanSwitchSelection = false;
            }
            else // En cas de déplacement en cours je change mon matérial
            {
                MySM.SwitchMyMaterial(3);
                MyEM.CanSwitchSelection = true;
            }
        }


        //////////////////////
        ///// Rotation //////
        ////////////////////

        if(IsSelected) // Si je suis selectionné je rotate en fonction de la valeur renvoyer par la molette
        {
            if(MyEM._MoletteValue > 0) 
            {
                gameObject.transform.Rotate(new Vector3(0,0,RotateSpeed), Space.Self);
            }
            if(MyEM._MoletteValue < 0)
            {
                gameObject.transform.Rotate(new Vector3(0,0,-RotateSpeed), Space.Self);
            }

        }
    }

    // En cas de collision je change ma variable
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Object")
        {
            //Debug.Log("Entrer");
            IsCollided = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Object")
        {
            //Debug.Log("Sortir");
            IsCollided = false;
        }
    }
}
