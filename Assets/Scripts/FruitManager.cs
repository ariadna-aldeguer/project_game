using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    // Comprueba si se han recolectado todas las fruitas
    public void AllFruitsCollected()
    {   
        // Una porque hay que comprobarlo antes de que se destruya
        if(transform.childCount == 1)
        {
            
        }
    }
}
