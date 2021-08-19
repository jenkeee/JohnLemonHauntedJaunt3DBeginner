using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //

public class GameEnding : MonoBehaviour
{/* выводим переменные в редактор */
    public float fadeDuration = 1f; // сколько будет исчезать появлятся
    public float displayImageDuration = 1f;  // сколько будет отображатся // мы не узнаем из под редакитора
   
    public GameObject player; // выводим в редактор возможность менять переменную плаер обозначенную юнити как GameObject
    // в редакторе GameObject имеет свои свойства
    public CanvasGroup exitBackgroundImageCanvasGroup; // выводим в редактор возможность получать кахвас группу.
                                                       // тоесть мы в редакторе можем сразу менять всякие картинки объеденные в канвас группы
    public AudioSource exitAudio; // у нас есть переменная для взаимодействия с канвасом на выход из игры / она же победа
    // добавим переменную для проигрованья звука

    public CanvasGroup caughtBackgroundImageCanvasGroup; //переменная для флага если поймали
    public AudioSource caughtAudio; // мы добавили звук для победы - добавим переменную звука и для пойман/проигрыш

    bool m_IsPlayerCaught; // флаг на поймали
    bool m_IsPlayerAtExit; // флаг на достигли мы тригер или нет
    float m_Timer; // переменная для таймера на канвас группу

    bool m_HasAudioPlayed; // флаг на играет звук или нет



    //(Collider otherCollider) эта запись значит что мы вызываем параметр метода про колайдеры и просто его както обозначаем в рамках этого метода otherCollider
    void OnTriggerEnter(Collider otherCollider) // OnTriggerEnter этот метод описан классом MonoBehaviour и позволяет получать флаг true когда колайдеры пересекаются.
    {// у нас по умолчанию есть колайдер объекта к которому мы привязали и нас интересует получать флаг true когда пересекаются колайдеры
        
        if (otherCollider.gameObject == player) //нас не особо интересуют пересечения всех колайдеров, да и их флаги .поэтому мы делаем уточняющее условие что нас интересует 
                                                //otherCollider.gameObject равный GameObject под переменной player;
        {
            m_IsPlayerAtExit = true; // если колайдер плеер пересекся с колайдером объекта мы даем в переменную m_IsPlayerAtExit правду. ура игрок достиг финиша
        }
    }
    public void CaughtPlayer() //метод который будет сообщать флаг тру если поймали. он публичный и мы его вызовем в другом скрипте
    {
        m_IsPlayerCaught = true;
    }


    void Update()
    {
        if (m_IsPlayerAtExit) // по другому это пишеться if (m_IsPlayerAtExit==true)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio); // если условие выполненно то выполним метод EndLevel
            // после изменения параметров на описание метода, обязательно добавим новые параметры и тут здесь у нас звук exitAudio
        }
        else if (player.transform.position.y > -30) m_IsPlayerCaught = true;
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio); // в параметре указываем от какого параметра получаем енд левл
            // здесь у нас звук caughtAudio
        }
    }
     
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource) // добавим параметры CanvasGroup как одну переменную imageCanvasGroup
                                                                                         // добавим параметр звука AudioSource audioSource как делали с канвасами
    {
        if (!m_HasAudioPlayed) //Это означает, что код в операторе if будет выполняться только в том случае, если звук не воспроизводится.
        {
            audioSource.Play(); // воспроизведем AudioSource в зависимости от получаемого параметра -
                                // audioSource = exitAudio или caughtAudio в зависимости от того  с каким параметром получит метод
            m_HasAudioPlayed = true; // установим флаг тру, чтобы воспроизведение было только 1 раз // до этого у нас был false
        }


        m_Timer += Time.deltaTime; // другая запись m_Timer = m_Timer + Time.deltaTime
        // будем перезаписывать m_Timer каждое время раз от начала тригера


        // будем менять альфа канал картинки каждый метод апдейт void Update() и в каждом Update мы вызовем EndLevel();
                                                                       // с другими цифрами так как += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration; // мы когда объявили метод указали параметр CanvasGroup и bool doRestart поэтому мы поменяли строчку
                                                         //exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;



        if (m_Timer > fadeDuration + displayImageDuration) // получим true когда m_Timer станет больше чем время когда картинка появляется и время
                                                           // получаем сумму, фейда и время до ресета или закрытия fadeDuration + displayImageDuration
            if (doRestart)
            {
                SceneManager.LoadScene(0); // если получим флаг doRestart перезагрузим игру
            }
            else
            {
                SceneManager.LoadScene("lvl2", LoadSceneMode.Single);
               // Application.Quit(); // если не получим флаг. то выйдем из игры
            }
    }
}