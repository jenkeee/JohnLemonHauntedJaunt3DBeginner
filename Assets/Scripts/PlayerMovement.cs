using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f; // скорость поворота

    Animator m_Animator; // ссылка на компонент аниматор
    Rigidbody m_Rigidbody; // ссылка на компонент ригитбади
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    public int speed_p = 1;
   //public static bool GetKeyDown(KeyCode 32);


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>(); //«Получите ссылку на компонент типа« Animator »и назначьте ее переменной с именем m_Animator».
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // у нас есть класс Input и в нем метод GetAxis и нас интересует горизонтальная ось и мы указываем это в () как параметр
        float horizontal = Input.GetAxis("Horizontal");
        // одновременно созданим переменную horizontal типа float 

        
        // повторим для вертикали
        float vertical = Input.GetAxis("Vertical");

        //Теперь у вас есть значения как для горизонтальной, так и для вертикальной осей.
        //Следующий шаг - объединить их в вектор , чтобы их можно было использовать для изменения положения.

        m_Movement.Set(horizontal, 0f, vertical); // установим значение m_Movement с нашими параметрами с типами float
        m_Movement.Normalize(); // фиксим баг пифагора
        m_Movement = m_Movement * speed_p;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); // проверяем есть ли горизонтальный ввод A D
        //Здесь вы создаете переменную типа bool (которая может иметь значение true или false) и вызываете ее hasHorizontalInput.
        //Затем вы устанавливаете это равным возвращаемому значению метода. Этот метод называется Approximately и принадлежит к классу Mathf.
        //Он принимает два параметра с плавающей запятой и возвращает логическое значение - истина,
        //если два числа с плавающей запятой приблизительно равны, и ложь в противном случае. 

        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking); // метод SetBool обращается к параметрам свойствам которые мы создали на компоненте аниматор ранее. Очень важен регистр

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        //Этот код создает переменную Vector3 с именем desireForward .
        //Он устанавливает его для возврата метода RotateTowards , который является статическим методом из класса Vector3.RotateTowards принимает четыре параметра
        //-первые два - это Vector3, и это векторы, которые поворачиваются соответственно из и в сторону.
        //Код начинается с transform.forward и нацелен на переменную m_Movement . transform.forward - это ярлык для доступа к компоненту Transform и получения его прямого вектора.
        //Следующие два параметра - это величина изменения между начальным вектором и целевым вектором: сначала изменение угла(в радианах),
        //а затем изменение величины. Этот код изменяет угол на turnSpeed ​​Time.deltaTime и величину на 0.

        m_Rotation = Quaternion.LookRotation(desiredForward); //Эта строка просто вызывает метод LookRotation и создает поворот, смотрящий в направлении параметра desiredForward.  
    }

    void OnAnimatorMove() // К счастью, в MonoBehaviours есть специальный метод, который вы можете использовать, чтобы изменить способ применения корневого движения из Animator.
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        // Во-первых, вы используете ссылку на компонент Rigidbody для вызова его метода MovePosition и передаете единственный параметр: его новую позицию.
        // Новое положение начинается с текущего положения Rigidbody, а затем вы добавляете к нему изменение - вектор движения,
        // умноженный на величину deltaPosition Animator. Но что это значит?
        // DeltaPosition Аниматора -это изменение положения из - за корневого движения, которое было бы применено к этому кадру.
        // Вы берете величину этого(его длину) и умножаете на вектор движения, который соответствует фактическому направлению, в котором мы хотим, чтобы персонаж двигался.
               
        m_Rigidbody.MoveRotation(m_Rotation); //  m_Rigidbody.MovePosition примерно тоже самое, но он применяется к вращению.
                                              //  На этот раз вы не изменяете вращение, вы просто устанавливаете вращение напрямую.

    }
}
