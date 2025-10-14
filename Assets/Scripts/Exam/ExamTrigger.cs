using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class ExamTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TriggerExam());
        }
    }

    private IEnumerator TriggerExam()
    {
        virtualCamera.Priority = 20;
        yield return new WaitForSeconds(2f);
        FindAnyObjectByType<ExamManager>().StartExam(virtualCamera);
    }
}
