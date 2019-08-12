using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chao : MonoBehaviour
{
    public Text Texto;
    int vida = 10;
    public Text perdi;
    public Balde balde;

    // Start is called before the first frame update
    void Start()
    {
        Texto.text = "Vidas: " + vida;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D A)
    {
        Destroy(A.gameObject);
        vida--;
        Texto.text = "Vidas: " + vida;

        if (vida <= 0)
        {
            perdi.text = "Você Perdeu";
            balde.perdeu = true;
        }
    }
}
