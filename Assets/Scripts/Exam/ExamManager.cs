using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    [SerializeField] private GameObject questionContainerPrefab;
    [SerializeField] private ExamSettings examSettings;

    private GameObject currentQuestionGameObject;
    private int correctAnswers;
    private int wrongAnswers;
    private int currentQuestionIndex = 0;

    [SerializeField] private GameObject resultGameObject;
    [SerializeField] private TextMeshProUGUI resultText;

    private CinemachineCamera examCinemachineCamera;

    [SerializeField] private Button closeButton;

    public void StartExam(CinemachineCamera cinemachineCamera=null)
    {
        examCinemachineCamera = cinemachineCamera;
        NextQuestion();
    }


    public void NextQuestion(bool isCorrect = false)
    {
        if (currentQuestionGameObject != null)
        {
            Destroy(currentQuestionGameObject);
            if(isCorrect)
            {
                correctAnswers++;
            }
            else
            {
                wrongAnswers++;
            }
            currentQuestionIndex++;
        }
        if (currentQuestionIndex < examSettings.questions.Count)
        {
            currentQuestionGameObject = Instantiate(questionContainerPrefab, transform);
            QuestionManager questionManager = currentQuestionGameObject.GetComponent<QuestionManager>();
            questionManager.Init(this,examSettings.questions[currentQuestionIndex], currentQuestionIndex + 1,examSettings.timePerQuestion);
        }
        else
        {
            ShowResult();
        }
    }

    private void ShowResult()
    {
        
        resultGameObject.SetActive(true);
        closeButton.onClick.AddListener(Close);
        float resultPercentage = ((float)correctAnswers / (float)examSettings.questions.Count) * 100f;
        resultText.text = $"{resultPercentage}% de respuestas correctas\n";
        if (resultPercentage >= 75)
        {
            resultText.text += "Aprobaste!\n";
        }
        else
        {
            resultText.text += "Desaprobaste!\n";
        }
        resultText.text += $"Respuestas correctas: {correctAnswers}\n";
        resultText.text += $"Respuestas incorrectas: {wrongAnswers}\n";

    }

    private void Close()
    {
        Destroy(gameObject);
        if (examCinemachineCamera != null)
        {
            examCinemachineCamera.Priority = 0;
        }
    }
}
