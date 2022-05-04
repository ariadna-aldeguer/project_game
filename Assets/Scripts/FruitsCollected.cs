using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitsCollected : MonoBehaviour
{

    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            FindObjectOfType<FruitManager>().AllFruitsCollected();         

            Destroy(gameObject, 0.5f);
            // Play al sonido de recolectar
            clip.Play();
        }
    }
}