using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    private int correctAnswers = 0;
    private int questionSeen = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public int GetQuestionSeen()
    {
        return questionSeen;
    }

    public void IncrementCorrectAnswer()
    {
        correctAnswers++;
    }

    public void IncrementQuestionSeen()
    {
        questionSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float) questionSeen * 100f);
    }


}