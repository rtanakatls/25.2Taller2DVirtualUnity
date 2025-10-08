using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class Question
{
    public string questionText;
    public List<string> answers;
    public int correctAnswerIndex;
}
