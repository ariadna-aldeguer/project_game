using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
       if(collision.transform.CompareTag("Player"))
       {
           // Muere nuestro personaje
           Destroy(collision.gameObject);
       }
   }
}
