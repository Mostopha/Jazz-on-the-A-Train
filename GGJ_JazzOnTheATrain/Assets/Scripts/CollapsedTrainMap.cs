using UnityEngine;
using System.Collections;

public class CollapsedTrainMap : PlayerProximityActivated
{
    public ExpandedTrainMap ExpandedTrainMap;
    // Use this for initialization
    public override void OnActivate()
    {
        ExpandedTrainMap.gameObject.SetActive(true);
    }
}
