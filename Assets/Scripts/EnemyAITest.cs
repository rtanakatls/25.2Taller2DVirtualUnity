using Pathfinding;
using UnityEngine;

public class EnemyAITest : MonoBehaviour
{
    void Start()
    {
        GetComponent<AIDestinationSetter>().target=GameObject.FindWithTag("Player").transform;
    }

}
