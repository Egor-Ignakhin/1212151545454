using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "EventDescriptionData", menuName = "ScriptableObjects/EventDescriptionData", order = 1)]
internal class EventDescriptionData : SerializedScriptableObject
{
    // ReSharper disable once MemberCanBePrivate.Global
    public Dictionary<EventType, Description> descriptions = new Dictionary<EventType, Description>();

    public string GetDescription(EventType eventType, bool isLastEvent, bool isEnLang)
    {
        if (isLastEvent)
            return string.Empty;

        return isEnLang ? descriptions[eventType].en : descriptions[eventType].ru;
    }
}