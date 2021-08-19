using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//��������� ������������ ���� AI ����������� ��� ������ � ������ NavMeshAgent .

public class ZombieWatPoint : MonoBehaviour
{
    public NavMeshAgent navMeshAgent; // ������� ���������� ������������ ��� ����������
    public Transform[] waypoints; // ������� � �������� ����� ����� ������� �� ������ ��������

    int m_CurrentWaypointIndex; // ������� ���������� ��� ��������� ������� ������ ���������� waypoints

    // Start is called before the first frame update
    void Start()
    { 
        //int r = (Random.Range(0, m_CurrentWaypointIndex +1));
        navMeshAgent.SetDestination(waypoints[(Random.Range(0, waypoints.Length))].position);  // navMeshAgent.SetDestination ��������� ������ ���������� �������� ������3.position
                                                                                  // �� ����� �������� ������ � �������� waypoints[0]
    }

    // Update is called once per frame
    void Update()
    {
        int r= Random.Range(0, waypoints.Length);
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) //�������� ������� ���� navMeshAgent ������� ��� remainingDistance ������ ��� stoppingDistance
                                                                            //������ �� �������������� � ���������� ������ using UnityEngine.AI; NavMeshAgent
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; // �������� ������� ������ 
            // ������� ����� � ������� 0 +1 ��� ����� �����. % ����� ���� ������� �� ���������� ��������� � ������ waypoints
            if (r != m_CurrentWaypointIndex)
            {
                navMeshAgent.SetDestination(waypoints[r].position); // ��������� ����� ��������
            }
        }
    }
}