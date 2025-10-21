using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowcaseController : MonoBehaviour
{
    private static ShowcaseController instance;
    public static ShowcaseController Instance { get { return  instance; } }


    [Header("UI Elements")]
    [SerializeField] private GameObject container;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button closeButton;

    [Header("Settings")]
    [SerializeField] private ShowcaseData showcaseData;


    private void Awake()
    {
        instance = this;
        closeButton.onClick.AddListener(Close);
    }

    private void Close()
    {
        container.SetActive(false);
    }

    public void Show(string name)
    {
        ShowcaseElementData data = GetData(name);
        if (data != null)
        {
            image.sprite = data.image;
            titleText.text = data.title;
            descriptionText.text = data.description;
            container.SetActive(true);
        }
    }

    private ShowcaseElementData GetData(string name)
    {
        foreach(ShowcaseElementData data in showcaseData.elements)
        {
            if(data.name == name)
            {
                return data;
            }
        }
        return null;
    }
}
