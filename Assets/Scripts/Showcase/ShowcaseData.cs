using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShowcaseData", menuName = "Game/ShowcaseData")]
public class ShowcaseData : ScriptableObject
{
    public List<ShowcaseElementData> elements;
}
