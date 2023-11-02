using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    TextMeshProUGUI textvictoria;
    [SerializeField]
    float speed;
    private Rigidbody2D rb2d;

    int punt = 0;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mH;
        float mV;

        if (Application.platform == RuntimePlatform.Android)
        {
            mH = Input.acceleration.x;
            mV = Input.acceleration.y;
        }
        else
        {
            mH = Input.GetAxis("Horizontal");
            mV = Input.GetAxis("Vertical");
        }

        
        Vector2 movement = new Vector2(mH,mV);
        rb2d.AddForce (movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Pickup")
        { 
            punt++;
            text.text = ("Puntuacio: " +punt.ToString() + " | Queden: " + (4-punt) + " Pickups per recollir");
            if (punt == 3)
            {
                text.text = ("Puntuacio: " + punt.ToString() + " | Queda: " + (4 - punt) + " Pickup per recollir");
            }
            Destroy(collision.gameObject);
        }

        if (punt == 4){
            text.text = text.text = ("Puntuacio: " + punt.ToString());
            textvictoria.text = ("Miquel Galvez, Has Guanyat!!!!");
        }
        
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
