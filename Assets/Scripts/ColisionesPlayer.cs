using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColisionesPlayer : MonoBehaviour
{
    public AudioSource reproductor;
    public AudioClip agua;
    public Image donkeykong;
    public GameObject video;


    void Start()
    {
        donkeykong.gameObject.SetActive(false);
        video.SetActive(false);

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "fuente")
        {
            reproductor.PlayOneShot(agua);
        }
        if (obj.tag == "comida")
        {
            donkeykong.gameObject.SetActive(true);
        }
        if (obj.tag == "cine")
        {
            video.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        reproductor.Stop();
        if (obj.tag == "comida")
        {
            donkeykong.gameObject.SetActive(false);
        }
        if (obj.tag == "cine")
        {
            video.SetActive(false);
        }

    }
}
