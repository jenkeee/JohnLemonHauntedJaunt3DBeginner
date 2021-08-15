using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{/* ������� ���������� � �������� */
    public float fadeDuration = 1f; // ������� ����� �������� ���������
    public float displayImageDuration = 1f;  // ������� ����� ����������� // �� �� ������ �� ��� ����������
    // ���������� ��� 2 ������ ����������, ����� �����������
    public GameObject player; // ������� � �������� ����������� ������ ���������� ����� ������������ ����� ��� GameObject
    // � ��������� GameObject ����� ���� ��������
    public CanvasGroup exitBackgroundImageCanvasGroup; // ������� � �������� ����������� �������� ������ ������.
                                                       // ������ �� � ��������� ����� ����� ������ ������ �������� ���������� � ������ ������


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

    void Update()
    {
        if (m_IsPlayerAtExit) // �� ������� ��� �������� if (m_IsPlayerAtExit==true)
        {
            EndLevel(); // ���� ������� ���������� �� �������� ����� EndLevel
                    }
    }

    void EndLevel() // ������ ����� EndLevel
    {
        m_Timer += Time.deltaTime; // ������ ������ m_Timer = m_Timer + Time.deltaTime
        // ����� �������������� m_Timer ������ ����� ��� �� ������ �������


        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration; // ����� ������ ����� ����� �������� ������ ����� ������ void Update() � � ������ Update �� ������� EndLevel();
                                                                       // � ������� ������� ��� ��� += Time.deltaTime; 

        if (m_Timer > fadeDuration + displayImageDuration) // ������� true ����� m_Timer ������ ������ ��� ����� ����� �������� ���������� � �����
                                                           // ����� ����� fadeDuration + displayImageDuration
        {
            Application.Quit(); //������� exe
        }
    }
}