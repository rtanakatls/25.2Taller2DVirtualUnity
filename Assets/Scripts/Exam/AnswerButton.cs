using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;

    public void Init(string text)
    {
        answerText.text = text;
    }
}
