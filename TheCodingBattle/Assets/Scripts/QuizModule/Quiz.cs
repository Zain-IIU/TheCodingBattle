using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace QuizModule
{
   public class Quiz : MonoBehaviour
   {
      private QuestionSO _currentQuestion;
      [SerializeField] private List<QuestionSO> questioSO = new List<QuestionSO>();
      [SerializeField] private TextMeshProUGUI questionText;
      [SerializeField] private GameObject[] answerButtons;
      private int _correctAnswerIndex;
      private bool _hasAnsweredEarly;
   
      private TimeManager _mTimeManager;

      [SerializeField] private TextMeshProUGUI scoreText;
      private ScoreManager _mScoreManager;

      public bool isCompleted;

      [SerializeField] private TextMeshProUGUI numberOfQuestionsRemaining;
      private int _totalQuestions;
      private int _currentQuestionIndex;
   
      [SerializeField] private Color defaultButtonColor;
      [SerializeField] private Color correctAnswerColor;
      [SerializeField] private Color wrongAnswerColor;
   
      private void Start()
      {
         _mTimeManager = FindObjectOfType<TimeManager>();
         _mScoreManager = FindObjectOfType<ScoreManager>();

         _totalQuestions = questioSO.Count;
      }

      private void Update()
      {
         if (_mTimeManager.loadNextQuestion)
         {
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _mTimeManager.loadNextQuestion = false;
         } 
         else if (!_hasAnsweredEarly && !_mTimeManager.isAnsweringQuestion)
         {
            DisplayAnswer(-1);
            SetButtonState(false);
         }
      }

      private void DisplayQuestion()
      {
         questionText.text = _currentQuestion.GetQuestion();

         for (int i = 0; i < answerButtons.Length; i++)
         {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuestion.GetAnswer(i);
         }
      }

      private void GetNextQuestion()
      {
         if (questioSO.Count > 0)
         {
            questionText.color = Color.white;
            SetButtonState(true);
            GetRandomQuestion();
            SetDefaultMethodSprites();
            DisplayQuestion();
            _mScoreManager.IncrementQuestionSeen();
            _currentQuestionIndex++;
         }

         if (_currentQuestionIndex == _totalQuestions)
         {
            isCompleted = true;
         }
      }

      private void GetRandomQuestion()
      {
         int index = Random.Range(0, questioSO.Count);
         _currentQuestion = questioSO[index];

         if (questioSO.Contains(_currentQuestion))
         {
            questioSO.RemoveAt(index);
         }

         numberOfQuestionsRemaining.text = "Questions: " + (_totalQuestions - questioSO.Count) + "/" + _totalQuestions;
      }

   
      public void OnAnswerSelected(int index)
      {
         _hasAnsweredEarly = true;
         DisplayAnswer(index);
         SetButtonState(false);
         _mTimeManager.CancelTimer();
         scoreText.text = "Score: " + _mScoreManager.CalculateScore() + "%";
      }

      private void DisplayAnswer(int index)
      {
         Image buttonImage;
         if (index == _currentQuestion.GetCorrectAnswerIndex())
         {
            questionText.color = correctAnswerColor;
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.color = correctAnswerColor;
            _mScoreManager.IncrementCorrectAnswer();
         }
         else
         {
            _correctAnswerIndex = _currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = _currentQuestion.GetAnswer(_correctAnswerIndex);
            buttonImage = answerButtons[_correctAnswerIndex].GetComponent<Image>();
         
            if (index == -1)
            {
           
               questionText.color = correctAnswerColor;
               questionText.text = "The correct answer is:\n" + correctAnswer;
               buttonImage = answerButtons[_correctAnswerIndex].GetComponent<Image>();
               buttonImage.color = correctAnswerColor;
               return;
            }
         
            var wrongImage = answerButtons[index].GetComponent<Image>();
            wrongImage.color = wrongAnswerColor;
            questionText.color = wrongAnswerColor;
            questionText.text = "Sorry, the correct answer is:\n" + correctAnswer;
         
        
            buttonImage.color = correctAnswerColor;
         }
      }

      private void SetButtonState(bool state)
      {
         for (int i = 0; i < answerButtons.Length; i++)
         {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
         }
      }

      private void SetDefaultMethodSprites()
      {
         for (int i = 0; i < answerButtons.Length; i++)
         {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.color = defaultButtonColor;
         }
      }
   
   }
}
