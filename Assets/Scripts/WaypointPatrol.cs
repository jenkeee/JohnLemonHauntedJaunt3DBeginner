using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//��������� ������������ ���� AI ����������� ��� ������ � ������ NavMeshAgent .

public class WaypointPatrol : MonoBehaviour
{

    public NavMeshAgent navMeshAgent; // ������� ���������� ������������ ��� ����������
    public Transform[] waypoints; // ������� � �������� ����� ����� ������� �� ������ ��������

    int m_CurrentWaypointIndex; // ������� ���������� ��� ��������� ������� ������ ���������� waypoints

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);  // navMeshAgent.SetDestination ��������� ������ ���������� �������� ������3.position
                                                             // �� ����� �������� ������ � �������� waypoints[0]
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) //�������� ������� ���� navMeshAgent ������� ��� remainingDistance ������ ��� stoppingDistance
                                                                            //������ �� �������������� � ���������� ������ using UnityEngine.AI; NavMeshAgent
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; // �������� ������� ������ 
            // ������� ����� � ������� 0 +1 ��� ����� �����. % ����� ���� ������� �� ���������� ��������� � ������ waypoints
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position); // ��������� ����� ��������
        }
    }
}
