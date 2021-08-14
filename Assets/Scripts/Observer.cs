using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    /// ////////////////// ���������� ��� ���������
    public Transform player; // �������� ������
    public GameEnding gameEnding; // ������ �� ���������� ��������, 
   
     
        bool m_IsPlayerInRange; // ���� ����������� ����������

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true; //���� ���� ���� ��������� �����������
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false; //������� ����
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange) // ���� ���� ��� m_IsPlayerInRange true
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            //���� ��� ������� ����� Vector3 � ������ direction . �� ��������� ���������� �� �����, ��� ������ �� A � B ����� B - A.
            //��� ��������, ��� ����������� �� GameObject PointOfView � JohnLemon - ��� ������� JohnLemon �� ������� ������� GameObject PointOfView.
            //��, ��������, �������, ��� ���� ����� ��������� �� ����� ����� ��� ������.����� ���������, ��� Observer ����� ����� ���� JohnLemon,
            //�� ���������� ����������� �� ���� ������� �����, �������� Vector3.up.Vector3.up - ��� ����� ���(0, 1, 0).


            Ray ray = new Ray(transform.position, direction); // �� ����� ��������� ��������������� ����������� � ������ ���������. ����� �� ������� ������ � ����������� ��������
             // Ray ��� ���                                   // ������ ���������� , ������������ ���������� �������� ������� 
             //������ ���������� �������� - �� �������

            RaycastHit raycastHit; // ������� ���������� ��� ��������� RaycastHit ������� ���������� ������� �������� , � �� ����������

            if (Physics.Raycast(ray, out raycastHit)) // Physics.Raycast(ray ���� ���� ����������� ������ ������� �������� � ���������� raycastHit
            {
                if (raycastHit.collider.transform == player) // ���� raycastHit � player 
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}