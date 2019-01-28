using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSong : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter see;

    // Start is called before the first frame update
    void Start()
    {
        see = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.get().ingredients[0])
        {
            see.SetParameter("WC3", 1f);
        }
        if (GameState.get().ingredients[1])
        {
            see.SetParameter("Swing1", 1f);
        }
        if (GameState.get().ingredients[2])
        {
            see.SetParameter("NOLA4", 1f);
        }
        if (GameState.get().ingredients[3])
        {
            see.SetParameter("Bebop2", 1f);
        }
    }
}
