using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
   [SerializeField] private float timeToCompleteQuestion = 30f;
   [SerializeField] private float timeToShowCorrectAnswer = 10f;
   
   [SerializeField] private Slider timerBar;

   public bool loadNextQuestion;
   public float fillFraction;
   
   public bool isAnsweringQuestion;
   private float timerValue;
   
   private void Update()
   {
      UpdateTimer();
   }

   public void CancelTimer()
   {
      timerValue = 0;
   }

   void UpdateTimer()
   {
      timerValue -= Time.deltaTime;

      if (isAnsweringQuestion)
      {
         if (timerValue > 0)
         {
            fillFraction = timerValue / timeToCompleteQuestion;
            timerBar.value = fillFraction;
         }
         else
         {
            isAnsweringQuestion = false;
            timerValue = timeToShowCorrectAnswer;
            timerBar.value = 1f;
         }
      }
      else
      {
         if (timerValue > 0)
         {
            fillFraction = timerValue / timeToShowCorrectAnswer;
            timerBar.value = fillFraction;
         }
         else
         {
            isAnsweringQuestion = true;
            timerValue = timeToCompleteQuestion;
            loadNextQuestion = true;
            timerBar.value = 1f;
         }
      }
   }
}
