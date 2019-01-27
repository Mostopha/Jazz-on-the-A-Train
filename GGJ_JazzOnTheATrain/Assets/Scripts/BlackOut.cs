using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using DG.Tweening;

public class BlackOut : MonoBehaviour
{
    Image blackOut;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        blackOut = GetComponent<Image>();
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeIn()
    {
        blackOut.DOFade(0, 2);
    }

    [YarnCommand("FadeOut")]
    public void FadeOut()
    {
        blackOut.DOFade(1, 2).OnComplete(LoadNext);
    }

    public void LoadNext ()
    {
        SceneChanger.sceneChanger.SwitchToScene(sceneName);
    }
}
