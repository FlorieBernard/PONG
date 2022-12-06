using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteScript : MonoBehaviour
{
    public float vitesse = 15f; 
    public string axe; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 RaquettePos = transform.position; //je récupère la position de la raquette et je la stocke dans une boite
        RaquettePos.y += Input.GetAxisRaw(axe) * vitesse * Time.deltaTime;  
        RaquettePos.y = Mathf.Clamp(RaquettePos.y , -30f, 30f); 
        transform.position = RaquettePos; 

    }
}
