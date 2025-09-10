using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBuff", menuName = "Buffs Settings/Speed")]
public class SpeedBuff : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    [SerializeField] private float cooldown;

    public float Speed { get { return speed; } }
    public float Duration { get { return duration; } }
    public float Cooldown { get { return cooldown; } }
}
