using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExamSettings", menuName = "Game/ExamSettings")]
public class ExamSettings : ScriptableObject
{
    public int timePerQuestion;
    public List<Question> questions;
}
