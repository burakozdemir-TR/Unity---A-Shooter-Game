using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    public Text shootCountText;
    private void Start()
    {
        Actions.shootCountUpdate += ShootCountUpdate;
    }
    public void PlayButton()
    {
        canvasGroup.DOFade(0, .5f).OnComplete(() =>
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Actions.mainMenuFadeOut?.Invoke();
        });
    }
    void ShootCountUpdate(PlayerShoot shootRef)
    {
        shootCountText.text = shootRef.shootCount.ToString();
    }
}
