using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{
    public Color correctColor;
    public Color mistakeColor;

    public GlobalEventInt correctEvent;
    public GlobalEventInt mistakeEvent;

    public List<Image> progressDots = new List<Image>();

    private void Update()
    {
        if (correctEvent.IsPublished)
        {
            progressDots[correctEvent.BatchedChanges.Peek()].color = correctColor;
        }

        if (mistakeEvent.IsPublished)
        {
            progressDots[mistakeEvent.BatchedChanges.Peek()].color = mistakeColor;
        }
    }
}