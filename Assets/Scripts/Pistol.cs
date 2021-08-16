using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject player;

    public AudioSource getPistol;

    bool m_HasAudioPlayed;
    bool m_IsPlayerGetPistol;

    public CanvasGroup PistolImage;
    float m_Timer;



    void Start()
    {

    }
    void OnTriggerEnter(Collider otherCollider)
    {

        if (otherCollider.gameObject == player)
        {
            m_IsPlayerGetPistol = true;
        }
    }


    void Update()
    {
        if (m_IsPlayerGetPistol)
        {
            GetPistol(PistolImage, getPistol);
        }
    }

    void GetPistol(CanvasGroup iamgePistol, AudioSource audioSource) 
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play(); 
            m_HasAudioPlayed = true; 
        }
        m_Timer += Time.deltaTime;  // нехочу чтоб моменталоьно картинка пистоля появлялась        
        iamgePistol.alpha = m_Timer / 2; // 
    }
}
