using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //

public class GameEnding : MonoBehaviour
{/* ������� ���������� � �������� */
    public float fadeDuration = 1f; // ������� ����� �������� ���������
    public float displayImageDuration = 1f;  // ������� ����� ����������� // �� �� ������ �� ��� ����������
   
    public GameObject player; // ������� � �������� ����������� ������ ���������� ����� ������������ ����� ��� GameObject
    // � ��������� GameObject ����� ���� ��������
    public CanvasGroup exitBackgroundImageCanvasGroup; // ������� � �������� ����������� �������� ������ ������.
                                                       // ������ �� � ��������� ����� ����� ������ ������ �������� ���������� � ������ ������
    public AudioSource exitAudio; // � ��� ���� ���������� ��� �������������� � �������� �� ����� �� ���� / ��� �� ������
    // ������� ���������� ��� ������������ �����

    public CanvasGroup caughtBackgroundImageCanvasGroup; //���������� ��� ����� ���� �������
    public AudioSource caughtAudio; // �� �������� ���� ��� ������ - ������� ���������� ����� � ��� ������/��������

    bool m_IsPlayerCaught; // ���� �� �������
    bool m_IsPlayerAtExit; // ���� �� �������� �� ������ ��� ���
    float m_Timer; // ���������� ��� ������� �� ������ ������

    bool m_HasAudioPlayed; // ���� �� ������ ���� ��� ���



    //(Collider otherCollider) ��� ������ ������ ��� �� �������� �������� ������ ��� ��������� � ������ ��� ����� ���������� � ������ ����� ������ otherCollider
    void OnTriggerEnter(Collider otherCollider) // OnTriggerEnter ���� ����� ������ ������� MonoBehaviour � ��������� �������� ���� true ����� ��������� ������������.
    {// � ��� �� ��������� ���� �������� ������� � �������� �� ��������� � ��� ���������� �������� ���� true ����� ������������ ���������
        
        if (otherCollider.gameObject == player) //��� �� ����� ���������� ����������� ���� ����������, �� � �� ����� .������� �� ������ ���������� ������� ��� ��� ���������� 
                                                //otherCollider.gameObject ������ GameObject ��� ���������� player;
        {
            m_IsPlayerAtExit = true; // ���� �������� ����� ��������� � ���������� ������� �� ���� � ���������� m_IsPlayerAtExit ������. ��� ����� ������ ������
        }
    }
    public void CaughtPlayer() //����� ������� ����� �������� ���� ��� ���� �������. �� ��������� � �� ��� ������� � ������ �������
    {
        m_IsPlayerCaught = true;
    }


    void Update()
    {
        if (m_IsPlayerAtExit) // �� ������� ��� �������� if (m_IsPlayerAtExit==true)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio); // ���� ������� ���������� �� �������� ����� EndLevel
            // ����� ��������� ���������� �� �������� ������, ����������� ������� ����� ��������� � ��� ����� � ��� ���� exitAudio
        }
        else if (player.transform.position.y > -30) m_IsPlayerCaught = true;
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio); // � ��������� ��������� �� ������ ��������� �������� ��� ����
            // ����� � ��� ���� caughtAudio
        }
    }
     
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource) // ������� ��������� CanvasGroup ��� ���� ���������� imageCanvasGroup
                                                                                         // ������� �������� ����� AudioSource audioSource ��� ������ � ���������
    {
        if (!m_HasAudioPlayed) //��� ��������, ��� ��� � ��������� if ����� ����������� ������ � ��� ������, ���� ���� �� ���������������.
        {
            audioSource.Play(); // ������������� AudioSource � ����������� �� ����������� ��������� -
                                // audioSource = exitAudio ��� caughtAudio � ����������� �� ����  � ����� ���������� ������� �����
            m_HasAudioPlayed = true; // ��������� ���� ���, ����� ��������������� ���� ������ 1 ��� // �� ����� � ��� ��� false
        }


        m_Timer += Time.deltaTime; // ������ ������ m_Timer = m_Timer + Time.deltaTime
        // ����� �������������� m_Timer ������ ����� ��� �� ������ �������


        // ����� ������ ����� ����� �������� ������ ����� ������ void Update() � � ������ Update �� ������� EndLevel();
                                                                       // � ������� ������� ��� ��� += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration; // �� ����� �������� ����� ������� �������� CanvasGroup � bool doRestart ������� �� �������� �������
                                                         //exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;



        if (m_Timer > fadeDuration + displayImageDuration) // ������� true ����� m_Timer ������ ������ ��� ����� ����� �������� ���������� � �����
                                                           // �������� �����, ����� � ����� �� ������ ��� �������� fadeDuration + displayImageDuration
            if (doRestart)
            {
                SceneManager.LoadScene(0); // ���� ������� ���� doRestart ������������ ����
            }
            else
            {
                SceneManager.LoadScene("lvl2", LoadSceneMode.Single);
               // Application.Quit(); // ���� �� ������� ����. �� ������ �� ����
            }
    }
}