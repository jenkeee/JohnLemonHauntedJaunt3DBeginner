using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{/* выводим переменные в редактор */
    public float fadeDuration = 1f; // сколько будет исчезать появлятся
    public float displayImageDuration = 1f;  // сколько будет отображатся // мы не узнаем из под редакитора
    // собственно эти 2 сверху неработают, будем разбираться
    public GameObject player; // выводим в редактор возможность менять переменную плаер обозначенную юнити как GameObject
    // в редакторе GameObject имеет свои свойства
    public CanvasGroup exitBackgroundImageCanvasGroup; // выводим в редактор возможность получать кахвас группу.
                                                       // тоесть мы в редакторе можем сразу менять всякие картинки объеденные в канвас группы


    bool m_IsPlayerAtExit; // флаг на достигли мы тригер или нет
    float m_Timer;



    //(Collider otherCollider) эта запись значит что мы вызываем параметр метода про колайдеры и просто его както обозначаем в рамках этого метода otherCollider
    void OnTriggerEnter(Collider otherCollider) // OnTriggerEnter этот метод описан классом MonoBehaviour и позволяет получать флаг true когда колайдеры пересекаются.
    {// у нас по умолчанию есть колайдер объекта к которому мы привязали и нас интересует получать флаг true когда пересекаются колайдеры
        
        if (otherCollider.gameObject == player) //нас не особо интересуют пересечения всех колайдеров, да и их флаги .поэтому мы делаем уточняющее условие что нас интересует 
                                                //otherCollider.gameObject равный GameObject под переменной player;
        {
            m_IsPlayerAtExit = true; // если колайдер плеер пересекся с колайдером объекта мы даем в переменную m_IsPlayerAtExit правду. ура игрок достиг финиша
        }
    }

    void Update()
    {
        if (m_IsPlayerAtExit) // по другому это пишеться if (m_IsPlayerAtExit==true)
        {
            EndLevel(); // если условие выполненно то выполним метод EndLevel
                    }
    }

    void EndLevel() // опишем метод EndLevel
    {
        m_Timer += Time.deltaTime; // другая запись m_Timer = m_Timer + Time.deltaTime
        // будем перезаписывать m_Timer каждое время раз от начала тригера


        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration; // будем менять альфа канал картинки каждый метод апдейт void Update() и в каждом Update мы вызовем EndLevel();
                                                                       // с другими цифрами так как += Time.deltaTime; 

        if (m_Timer > fadeDuration + displayImageDuration) // получим true когда m_Timer станет больше чем время когда картинка появляется и время
                                                           // когда висит fadeDuration + displayImageDuration
        {
            Application.Quit(); //закроем exe
        }
    }
}