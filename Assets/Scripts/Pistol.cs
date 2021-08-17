using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pistol : MonoBehaviour
{
    public GameObject player;

    public AudioSource getPistol;

    bool m_HasAudioPlayed;
    bool m_IsPlayerGetPistol;

    public CanvasGroup PistolImage;
    float m_Timer;

   [Tooltip("The target object on which to operate.  If null, then the current behaviour/GameObject will be used")]
    public UnityEngine.Object m_Target;




    void Start()
    {

    }
    void OnTriggerEnter(Collider otherCollider)
    {

        if (otherCollider.gameObject == player)
        {
            m_IsPlayerGetPistol = true;
            
            UnityEngine.Object currentTarget = m_Target;
            if (currentTarget != null)
            {
                GameObject targetGameObject = currentTarget as GameObject;
                Behaviour targetBehaviour = currentTarget as Behaviour;
                if (targetBehaviour != null)
                    targetGameObject = targetBehaviour.gameObject;
                if (targetGameObject != null)
                    targetGameObject.SetActive(false);
            }
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

