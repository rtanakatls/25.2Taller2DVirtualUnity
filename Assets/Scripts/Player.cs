using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    
    
    [Header("Buffs")]
    [SerializeField] private SpeedBuff speedBuff;
    private bool canUseSpeedBuff;


    private void Awake()
    {
        canUseSpeedBuff = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb2d.linearVelocity = new Vector2(h, v).normalized * speed;

        if(Input.GetKeyDown(KeyCode.Alpha1) && canUseSpeedBuff)
        {
            StartCoroutine(EnableSpeedBuff());
        }
    }

    private IEnumerator EnableSpeedBuff()
    {
        canUseSpeedBuff = false;
        speed += speedBuff.Speed;
        yield return new WaitForSeconds(speedBuff.Duration);
        speed -= speedBuff.Speed;
        yield return new WaitForSeconds(speedBuff.Cooldown);
        canUseSpeedBuff = true;
    }

}
