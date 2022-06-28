using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectThis : MonoBehaviour
{
    private Edit_Manager MyEM;
    public LayerMask WhoIsInteragible; // Layer qui sera pris en compte pour les raycasts
    public Transform TransformCamera; // Transform de la camera
    public Transform PosPointForward; // Direction "Forward" local de la camera
    public float RangeInteraction; // Distance jusqu'a la quelle je peux intéragir

    private bool MouseDown; // Variable qui passe à true lorsque j'appuie
    private bool MouseDownRight; // Vairable qui passe à true lorsque j'appuie avec le clique droit

    void Start()
    {
        MyEM = Edit_Manager._EM;
        Cursor.visible = false; // Désactive le curseur.
    }

    private void OnMouseDown() // Lorsque que j'appuie
    {
        //Debug.Log("Click");
        MouseDown = true;
    }

    private void OnMouseDownRight() // Lorsque j'appuie avec le clique droit
    {
        MouseDownRight = true;
        
    }

    void Update()
    {
        // if(Cursor.visible != false){Cursor.visible = false;} // Ligne inutile dans une build , cependant permet de ne pas voir la souris dans l'éditeur même quand on lance le jeu avec la souris sortie du cadre.
        if(MouseDown) // Si j'appuie et que mon raycast touche un objet alors que change mon objet selectionné avec celui-ci.
        {
            Vector3 LocalForwardCamera = PosPointForward.position - TransformCamera.position;
            RaycastHit hit;
            if (Physics.Raycast(TransformCamera.position, LocalForwardCamera, out hit, RangeInteraction, WhoIsInteragible))
            {
                MyEM.SelectThis(hit.collider.gameObject.GetComponent<Root>().MyRoot);
            }
            MouseDown = false;
        }

        if(MouseDownRight) // Si j'appuie et que mon raycast touche un objet alors je change son matérial stantard.
        {
            Vector3 LocalForwardCamera = PosPointForward.position - TransformCamera.position;
            RaycastHit hit;
            if (Physics.Raycast(TransformCamera.position, LocalForwardCamera, out hit, RangeInteraction, WhoIsInteragible))
            {
                MyEM.SwitchMaterialStandard(hit.collider.gameObject.GetComponent<Root>().MyRoot);
            }

            MouseDownRight = false;
        }

    }

}
