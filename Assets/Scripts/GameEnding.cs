using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //

public class GameEnding : MonoBehaviour
{/* ������� ���������� � �������� */
    public float fadeDuration = 1f; // ������� ����� �������� ���������
    public float displayImageDuration = 1f;  // ������� ����� ����������� // �� �� ������ �� ��� ����������
    // ���������� ��� 2 ������ ����������, ����� �����������
    public GameObject player; // ������� � �������� ����������� ������ ���������� ����� ������������ ����� ��� GameObject
    // � ��������� GameObject ����� ���� ��������
    public CanvasGroup exitBackgroundImageCanvasGroup; // ������� � �������� ����������� �������� ������ ������.
                                                       // ������ �� � ��������� ����� ����� ������ ������ �������� ���������� � ������ ������
    public CanvasGroup caughtBackgroundImageCanvasGroup; //���������� ��� ����� ���� �������

    bool m_IsPlayerCaught; // ���� �� �������
    bool m_IsPlayerAtExit; // ���� �� �������� �� ������ ��� ���
    float m_Timer;



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
            EndLevel(exitBackgroundImageCanvasGroup, false); // ���� ������� ���������� �� �������� ����� EndLevel
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true); // � ��������� ��������� �� ������ ��������� �������� ��� ����
        }
    }
     
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart) // ������� ��������� CanvasGroup ��� ���� ���������� imageCanvasGroup
    { 
        m_Timer += Time.deltaTime; // ������ ������ m_Timer = m_Timer + Time.deltaTime
        // ����� �������������� m_Timer ������ ����� ��� �� ������ �������


        // ����� ������ ����� ����� �������� ������ ����� ������ void Update() � � ������ Update �� ������� EndLevel();
                                                                       // � ������� ������� ��� ��� += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;


        if (m_Timer > fadeDuration + displayImageDuration) // ������� true ����� m_Timer ������ ������ ��� ����� ����� �������� ���������� � �����
                                                           // ����� ����� fadeDuration + displayImageDuration
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
    }
}