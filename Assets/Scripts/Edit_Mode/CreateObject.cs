using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    // Listes de toute les formes possibles à créer
    public List<GameObject> MyPrefabsObjects;

    // Référence au Singleton
    private Edit_Manager MyEM;

    void Start()
    {
        MyEM = Edit_Manager._EM;
    }

    public void OnPress1() // Lorsque je press le bouton 1
    {
        if(MyEM.CanCreateObject)
        {
            CreateWithIndex(0);
        }
    }

    public void OnPress2() // Lorsque je press le bouton 2
    {
        if(MyEM.CanCreateObject)
        {
            CreateWithIndex(1);
        }
    }

    public void OnPress3() // Lorsque je press le bouton 3
    {
        if(MyEM.CanCreateObject)
        {
            CreateWithIndex(2);
        }
    }

    public void OnPress4() // Lorsque je press le bouton 4
    {
        if(MyEM.CanCreateObject)
        {
            CreateWithIndex(3);
        }
    }

    void CreateWithIndex(int index)
    {
        if(MyEM.CanCreateObject) // Je vérifie que j'ai le droit de crée un objet
        {
            if(index == 0 || index == 1) // S'il s'agit des 2 premières éléments de ma listes , j'adapte leurs spawn sur l'axe Y
            {
                GameObject LastInstantiate = Instantiate(MyPrefabsObjects[index], new Vector3(0.5f,0.5f,-0.5f), Quaternion.identity);
                MyEM.SelectThis(LastInstantiate);
            }
            else
            {
                GameObject LastInstantiate = Instantiate(MyPrefabsObjects[index], new Vector3(0.5f,1,-0.5f), Quaternion.identity);
                MyEM.SelectThis(LastInstantiate);
            }
        }
    }
}
