using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    public UnityAction mainMenuFadeOut;//wip
    public void PlayButton()
    {
        canvasGroup.DOFade(0, .5f).OnComplete(()=>
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        });
    }
}
