using UnityEngine;

[System.Serializable]
public class Q3QuestionAndAnswers
{
    [TextArea]
    public string Question;
    [TextArea]
    public string[] Answers;
    public int CorrectAnswer;
    
    [SerializeField]
    public int QuestionNum;

}

