using UnityEngine;

[System.Serializable]
public class Q6QuestionAndAnswers
{
    [TextArea]
    public string Question;
    [TextArea]
    public string[] Answers;
    public int CorrectAnswer;

}

