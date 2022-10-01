using UnityEngine;

[CreateAssetMenu(fileName = "EventDescriptionData", menuName = "ScriptableObjects/EventDescriptionData", order = 1)]
internal class EventDescriptionData : ScriptableObject
{
  //  [SerializeField]
  public string GetDescriptionByEventIndex(int currentEventIndex, int maxEventIndex)
  {
    if (currentEventIndex == maxEventIndex)
      return string.Empty;
    
    return null;
  }
}