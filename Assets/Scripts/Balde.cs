using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balde : MonoBehaviour
{

    float EixoX;
    public float velmaxima = 5.0f;

    public int ra;
    public float Tempo = 0f;

    public GameObject gota;
    public Transform[] possição;
    public chao chao;

    public float ContaPonto = 0f;

    Rigidbody2D rbBalde;
    Animator animatorBalde;

    public bool perdeu = false;

    // Start is called before the first frame update
    void Start()
    {
        rbBalde = GetComponent<Rigidbody2D>();
        animatorBalde = GetComponent<Animator>();
    }

    void FixedUpdate()
    {      
        if (!perdeu)
        {
             float vel = EixoX * velmaxima;
             rbBalde.velocity = new Vector2(vel * Time.deltaTime, rbBalde.velocity.x);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!perdeu)
        {
            EixoX = Input.GetAxis("Horizontal");

            InvokeRepeating("FazGota", 3f, 5f);

            if (ContaPonto <= 4)
            {
                animatorBalde.SetInteger("trans", 0);
            }
            else if (ContaPonto >= 5 && ContaPonto <= 9)
            {
                animatorBalde.SetInteger("trans", 1);
            }
            else if (ContaPonto == 10)
            {
                animatorBalde.SetInteger("trans", 2);
            }
            else if (ContaPonto >= 10)
            {
                chao.perdi.text = "Você encheu demais o balde";
                perdeu = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && ContaPonto == 10)
            {
                animatorBalde.SetInteger("trans", 0);
                ContaPonto = 0;
            }
        }
        if (perdeu)
        {
            EixoX = 0f;
            velmaxima = 0f;
        }

    }

    public void FazGota()
    {
        if (!perdeu)
        {
            Tempo = Tempo + Time.deltaTime;
            if (Tempo > 1f)
            {
                ra = Random.Range(0, 10);
                Instantiate(gota, possição[ra]);
                Tempo = 0f;
            }
        }

        //int n = Random.Range(0,9);
        //InvokeRepeating("FazGota", 10f, 2f);
    }

    public void OnTriggerEnter2D(Collider2D A)
    {
        if (!perdeu)
        {
            ContaPonto += 1;
            Destroy(A.gameObject);
        }
    }
}
