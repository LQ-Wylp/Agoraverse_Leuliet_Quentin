using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterial : MonoBehaviour
{
    public MeshRenderer MyMR;
    public List<Material> List_Standard_Materials; // Listes dans laquel l'on stock tout les matérials qui défilerons en cas de clique droit sur un objet.
    private int Index = 0;
    public Material Standard_Material; // Case 1
    public Material Selected_Material; // Case 2
    public Material CanMoveHere_Material; // Case 3
    public Material CantMoveHere_Material; // Case 4

    public void Start()
    {
        Standard_Material = List_Standard_Materials[Index];
    }

    public void SwitchMyMaterial(int etat)
    {
        switch (etat) // En fonction de l'état envoyer je change mon matérial.
        {
            case 1 : MyMR.material = Standard_Material; break;
            case 2 : MyMR.material = Selected_Material; break;
            case 3 : MyMR.material = CanMoveHere_Material; break;
            case 4 : MyMR.material = CantMoveHere_Material; break;
        }
    }

    public void SwitchStandardMaterial() // Je met le matérial suivant dans la liste "List_Standard_Materials" à l'objet.
    {
        Index++;
        if(Index >= List_Standard_Materials.Count){Index = 0;}
        Standard_Material = List_Standard_Materials[Index];
    }
}
