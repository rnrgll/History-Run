using UnityEngine;

[System.Serializable]
public class P2QuestionAndAnswers
{
    [TextArea]
    public string Question; 
    [SerializeField]
    public bool True;
    [SerializeField]
    public int QuestionNum;

}

