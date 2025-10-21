using UnityEngine;

public class ShowcaseInteraction : MonoBehaviour
{
    [SerializeField] private string showcaseElementName;

    private bool isPlayerInRange;

    private void Update()
    {
        if(isPlayerInRange&& Input.GetKeyDown(KeyCode.E))
        {
            ShowcaseController.Instance.Show(showcaseElementName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
