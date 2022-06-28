using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Edit_Manager : MonoBehaviour
{
    // Mise en place du Singleton
    public static Edit_Manager _EM;
    public void Awake()
    {
        if(Edit_Manager._EM != null)
        {
            Destroy(this);
        }
        else
        {
            Edit_Manager._EM = this;
        }
    }
    
    public GameObject ObjectSelected; // L'objet que je suis entrain de manipuler
    public Vector2 _MoveInput; // Vecteur obtenue grâce aux flêches directrices
    public float _MouseX; // Mouvement de la souris sur X
    public float _MouseY; // Mouvement de la souris sur Y

    public float _MoletteValue; // Mouvement de la Molette

    public bool CanSwitchSelection = true; // Variable définissant si j'ai le droit de changer de sélection

    public DisplayAlerte MyDA; // Référence au scripts qui gére les alertes en cas d'action interdit

    public bool CanCreateObject = true; // Variable définissant si à l'instant t je peux crée un nouvelle objet

    public GameObject InfosCreate_UI; // Référence au gameobject contenant un groupe d'UI
    public GameObject InfosMoveRotate_UI; // Référence au gameobject contenant un groupe d'UI

    public void OnMove(InputValue value) // Lorsque j'appuie sur une flèche directive
    {
        _MoveInput = value.Get<Vector2>();
    }

    public void OnMolette(InputValue value) // Lorsque je fais rouler la molette
    {
        _MoletteValue = value.Get<Vector2>().y;
    }

    public void OnDelete() // Lorsque j'appuie sur Suppr
    {
        if(ObjectSelected != null)
        {
            Destroy(ObjectSelected.gameObject);
            ObjectSelected = null;
        }
    }

    public void OnMousePosition(InputValue value) // Lorsque je déplace la souris
    {
        _MouseX = value.Get<Vector2>().x;
        _MouseY = value.Get<Vector2>().y;
    }
    
    public void SelectThis(GameObject NewObjectSelected) // Fonction permetant de changer d'objet sélectionné
    {
        if(CanSwitchSelection)
        {
            if(ObjectSelected != null)
            {
                ObjectSelected.GetComponent<Move_Object>().IsSelected = false;
            }
            if(ObjectSelected == NewObjectSelected)
            {
                ObjectSelected = null;
            }
            else
            {
                ObjectSelected = NewObjectSelected;

                Move_Object Select_MO = ObjectSelected.GetComponent<Move_Object>();
                Select_MO.IsSelected = true;
                Select_MO.IsMovingMode = false;
            }
        }
        else
        {
            MyDA.ShowAlerte();
        }
    }

    public void SwitchMaterialStandard(GameObject GO) // Fonction permettant de change le matérial d'un objet
    {
        GO.GetComponent<SwitchMaterial>().SwitchStandardMaterial();
    }

    void Update()
    {
        if(ObjectSelected == null) // En cas d'objet sélectionné
        {
            CanCreateObject = true;
            InfosCreate_UI.SetActive(true);
            InfosMoveRotate_UI.SetActive(false);
        }
        else // En cas d'objet non sélectionné
        {
            CanCreateObject = false;
            InfosCreate_UI.SetActive(false);
            InfosMoveRotate_UI.SetActive(true);
        }
    }
}

