using UnityEngine;

public class ExamManager : MonoBehaviour
{
    [SerializeField] private GameObject questionContainerPrefab;
    [SerializeField] private ExamSettings examSettings;

    private GameObject currentQuestionGameObject;
    [SerializeField] private int correctAnswers;
    [SerializeField] private int wrongAnswers;
    private int currentQuestionIndex = 0;   

    private void Start()
    {
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
            Debug.Log("Se acabaron las preguntas");
        }
    }
}
