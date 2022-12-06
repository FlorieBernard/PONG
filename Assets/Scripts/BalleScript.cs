using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour

    
{
    [Range(1,100)] public float ScoreMax = 11;

    public int scoreJoueurGauche = 0;
    public int scoreJoueurDroit = 0;

    [Range(1f,100f)] public float vitesseMax = 5f;

    public string nomJoueurGauche = "Toto";
    public string nomJoueurDroit = "Titi";

    public bool enPause = false;

    public Rigidbody body;

    public TextMesh scoreJ1, scoreJ2;

    float direction;

    void Start()
    {
        NouvellePartie(); // On lance une nouvelle partie dès le démarrage du jeu 
    }

    void NouvellePartie()
     {
        scoreJoueurDroit = 0; // on remet les score à zéro
        scoreJoueurGauche = 0;
        NouvelleBalle(); // on commence une nouvelle partie
        
    }

    // Update is called once per frame
    void Update()
    {
        DetecterBut(); // j'appelle la fonction detecterbut() 
    }

    void DetecterBut()
    {
        if (transform.position.x >36f) // si balle sort écran droite
        {
            ButJ1(); 
            Debug.Log("+1 Point");
        }
        if (transform.position.x <-36f) // si balle sort écran gauche 
         {
            ButJ2(); 
            Debug.Log("+1 Point");
        }
    }

    void ButJ1()
    {
        scoreJoueurGauche += 1;  
        //directionLancerX =1f;
        NouvelleBalle();
        //AudioSource.PlayClipAtPoint (sonBut, Vector3.right*10f); // je joue le son a 10m
    }
    
    void NouvelleBalle()
    
    {
        CancelInvoke();
        if (scoreJoueurDroit>=ScoreMax || scoreJoueurGauche>=ScoreMax) Invoke("GameOver",2f);
        scoreJ1.text = nomJoueurGauche + "\n" + scoreJoueurGauche;
        scoreJ2.text = nomJoueurDroit + "\n" + scoreJoueurDroit;
        body.velocity = Vector3.zero; // on arrête la balle
        transform.position = Vector3.zero; // on remet la balle au centre 
        Invoke("LancerBalle", 2f); // on attend deux secondes puis on lance la balle

    }

    void LancerBalle()
    {
        Vector3 direction = Vector3.one; 

        if (Random.value > 0.5f) direction.x = -1f;
        if (Random.value > 0.5f) direction.y = -1f;

        body.AddForce(direction.normalized * (vitesseMax+(scoreJoueurDroit+scoreJoueurGauche)*20f), ForceMode.VelocityChange); // on lance la balle
    }

    void ButJ2()
    {
        scoreJoueurDroit += 1;  
        //directionLancerX = 1f;
        //AudioSource.PlayClipAtPoint (sonBut, Vector3.left*10f);
        NouvelleBalle();
    }
    
    void GameOver()
    {
        NouvellePartie();
    }
    
}