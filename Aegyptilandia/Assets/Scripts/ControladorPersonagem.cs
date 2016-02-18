﻿using UnityEngine;
using System.Collections;

public class ControladorPersonagem : MonoBehaviour
{

    #region Atributos e propriedade

    public bool andar;
    public float direcaoMovimento;
    public Animator Anim;
    public Rigidbody2D RbPersonagem;
    public float maxSpeed;
    public bool facingRight;
    public bool wallCheck;

    public bool atacar;

    public BoxCollider2D colliderChao;
    public float JumpForce;
    public Transform GroundCheck;
    public bool grounded;
    public LayerMask WhatIsGround;
    public bool puloDuplo;

    public bool agachar;

    public GameObject objetoInteracao;

    //Atributos diretos do personagem

    public int Coins;
    public float vida;

    //Itens pertencentes ao invertário

    public int veneno;
    public int aguaSanitaria;
    public bool areia;

    public GameObject ControladorAtaque;

    #endregion Atributos e propriedades

    #region Métodos
    // Use this for initialization
    void Start()
    {
        andar = false;
        wallCheck = false;
        puloDuplo = false;

        Coins = 0;
        vida = 100;
        veneno = 0;
        aguaSanitaria = 0;
        areia = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Controla o movimento de andar do personagem

        Anim.SetBool("walk", andar);
        Anim.SetBool("Grounded", grounded);
        Anim.SetBool("atacar", atacar);
        Anim.SetFloat("SpeedY", RbPersonagem.velocity.y);
        Anim.SetBool("agachar", agachar);

        direcaoMovimento = Input.GetAxis("Horizontal");

        if (!wallCheck)
        {
            RbPersonagem.velocity = new Vector2(direcaoMovimento * maxSpeed, RbPersonagem.velocity.y);
        }

        if (direcaoMovimento != 0)
        {
            andar = true;

        }
        else {
            andar = false;
        }
        if (direcaoMovimento > 0 && !facingRight)
        {
            Inverter();
        }
        else if (direcaoMovimento < 0 && facingRight)
        {
            Inverter();
        }

        //Controla o movimento de ataque do personagem

        if (Input.GetAxis("Fire1") != 0)
        {
            atacar = true;
        }
        else
        {
            atacar = false;
        }

        //Controle de salto do personagem

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, WhatIsGround);

        if (grounded == true)
        {
            puloDuplo = false;
        }

        if (Input.GetButtonDown("Jump") && (grounded || !puloDuplo))
        {
            RbPersonagem.AddForce(new Vector2(0, JumpForce));

            RbPersonagem.velocity = new Vector2(0, 0);

            ControladorSom.playSound(soundFx.Pulo);

            if (!grounded && !puloDuplo)
            {
                puloDuplo = true;
            }

        }

        //Controle de agachamento do personagem

        if (Input.GetAxis("Fire2") != 0)
        {
            agachar = true;
        }
        else
        {
            agachar = false;
        }

        //Controla a intereção com objetos

        if(Input.GetAxis("Submit") != 0 && objetoInteracao != null)
        {
            objetoInteracao.SendMessage("interacao", SendMessageOptions.DontRequireReceiver);
        }

        if(vida <= 0)
        {
            Debug.Log("Morreu!");
        }
    }

    void Inverter()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Mosquito")
        {
            this.vida -= 5;
            ControladorSom.playSound(soundFx.Picado);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "interacao")
        {
            objetoInteracao = col.gameObject;
        }
    }

    #endregion Métodos
}
