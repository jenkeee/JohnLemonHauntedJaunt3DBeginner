using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Включение пространства имен AI предоставит вам доступ к классу NavMeshAgent .

public class ZombieWatPoint : MonoBehaviour
{
    public NavMeshAgent navMeshAgent; // добавим переменную навмешагента для инспектора
    public Transform[] waypoints; // добавим в редактор некий масив который мы сможем изменять

    int m_CurrentWaypointIndex; // объявим переменную для значкения индекса масива переменных waypoints

    // Start is called before the first frame update
    void Start()
    { 
        //int r = (Random.Range(0, m_CurrentWaypointIndex +1));
        navMeshAgent.SetDestination(waypoints[(Random.Range(0, waypoints.Length))].position);  // navMeshAgent.SetDestination принимает первым параметром значение вектор3.position
                                                                                  // мы берем значение масива с индексом waypoints[0]
    }

    // Update is called once per frame
    void Update()
    {
        int r= Random.Range(0, waypoints.Length);
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) //выполним условие если navMeshAgent сообщит нам remainingDistance меньше чем stoppingDistance
                                                                            //тоесть мы взаимодейсвием с параметраи подуля using UnityEngine.AI; NavMeshAgent
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; // вычислим текущий индекс 
            // текущий поинт к примеру 0 +1 это левая часть. % делим безх остатка на количество элементов в масиве waypoints
            if (r != m_CurrentWaypointIndex)
            {
                navMeshAgent.SetDestination(waypoints[r].position); // установим новый выйпоинт
            }
        }
    }
}