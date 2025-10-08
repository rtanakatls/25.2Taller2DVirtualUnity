using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    private List<Button> buttons;
    private Button correctButton;
    private ExamManager examManager;

    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionNumberText;
    [SerializeField] private TextMeshProUGUI questionTitleText;
    private Question currentQuestion;

    [Header("Answers")]
    [SerializeField] private GameObject answersContainer;
    [SerializeField] private GameObject answerButtonPrefab;


    [Header("Timer")]
    [SerializeField] private Image timerImage;
    private float currentTimer;
    private float maxTimer;
    private bool timerActive;



    public void Init(ExamManager examManager, Question question, int currentQuestionNumber, float timer)
    {
        timerActive = true;
        currentTimer = timer;
        maxTimer = timer;

        buttons = new List<Button>();

        this.examManager = examManager;

        currentQuestion = question;
        questionNumberText.text = $"Pregunta {currentQuestionNumber}";
        questionTitleText.text = question.questionText;

        List<Answer> answers = new List<Answer>();
        for (int i = 0; i < question.answers.Count; i++)
        {
            answers.Add(new Answer { answerText = question.answers[i], answerIndex = i });
        }

        for (int i = 0; i < question.answers.Count; i++)
        {
            Answer randomAnswer = GetRandomAnswer(answers);
            GameObject obj = Instantiate(answerButtonPrefab, answersContainer.transform);
            AnswerButton answerButton = obj.GetComponent<AnswerButton>();
            answerButton.Init(randomAnswer.answerText);
            buttons.Add(obj.GetComponent<Button>());
            obj.GetComponent<Button>().onClick.AddListener(() => OnAnswerClicked(obj, randomAnswer.answerIndex));
            if (randomAnswer.answerIndex == question.correctAnswerIndex)
            {
                correctButton = obj.GetComponent<Button>();
            }
        }
    }

    private Answer GetRandomAnswer(List<Answer> answers)
    {
        Answer randomAnswer = answers[Random.Range(0, answers.Count)];
        answers.Remove(randomAnswer);
        return randomAnswer;
    }

    private void OnAnswerClicked(GameObject button,int index)
    {
        StartCoroutine(AnswerProcess(button,index));
    }

    private IEnumerator AnswerProcess(GameObject button, int index)
    {
        timerActive = false;
        bool isCorrect = index == currentQuestion.correctAnswerIndex;

        foreach (Button b in buttons)
        {
            b.interactable = false;
        }

        if (isCorrect)
        {
            button.GetComponent<Image>().color = Color.green;
        }
        else
        {
            button.GetComponent<Image>().color = Color.red;
            if (correctButton != null)
            {
                correctButton.GetComponent<Image>().color = Color.green;
            }
        }

        yield return new WaitForSeconds(1f);


        if (isCorrect)
        {
            examManager.NextQuestion(true);
        }
        else
        {
            examManager.NextQuestion(false);
        }
    }

    private void Update()
    {
        if(!timerActive)
        {
            return;
        }

        currentTimer -= Time.deltaTime;
        timerImage.fillAmount = currentTimer/maxTimer;
        if (currentTimer<= 0)
        {
            examManager.NextQuestion(false);
        }

    }
}
