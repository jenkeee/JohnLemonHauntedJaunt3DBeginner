using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    /// ////////////////// переменные для редактора
    public Transform player; // колайдер плеера
    public GameEnding gameEnding; // ссылка на геймеднинг картинку, 
   
     
        bool m_IsPlayerInRange; // флаг пересечения колайдеров

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true; //ддим флаг если колайдеры пересеклись
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false; //заберем флаг
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange) // если флаг тру m_IsPlayerInRange true
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            //Этот код создает новый Vector3 с именем direction . Из векторной математики мы знаем, что вектор от A к B равен B - A.
            //Это означает, что направление от GameObject PointOfView к JohnLemon - это позиция JohnLemon за вычетом позиции GameObject PointOfView.
            //Вы, возможно, помните, что Джон Лимон находится на земле между его ногами.Чтобы убедиться, что Observer видит центр масс JohnLemon,
            //вы указываете направление на одну единицу вверх, добавляя Vector3.up.Vector3.up - это ярлык для(0, 1, 0).


            Ray ray = new Ray(transform.position, direction); // мы будем проверять непосредсвенное пересечение в линнии видимости. Ранее мы создали вектор в направление которого
             // Ray это луч                                   // внутри колайдеров , проверяеться персечение пикселей моделей 
             //вернет логическое значение - не булевое

            RaycastHit raycastHit; // создаем переменную для структуры RaycastHit которая возвращает булевое значение , а не логичсекое

            if (Physics.Raycast(ray, out raycastHit)) // Physics.Raycast(ray если есть пересечения вернет булевое значение в переменную raycastHit
            {
                if (raycastHit.collider.transform == player) // если raycastHit с player 
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}