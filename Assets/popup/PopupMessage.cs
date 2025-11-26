using System;
using TMPro;
using UnityEngine;

public class PopupMessageInfo
{
    public readonly string title;
    public readonly string message;

    public PopupMessageInfo(string title, string message)
    {
        this.title = title;
        this.message = message;
    }
}

public class PopupMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text textTitle;
    [SerializeField] private TMP_Text contentTitle;

    private PopupMessageInfo popupMessageInfo;
    private Action cancleACtion;
    private Action okAction;
    public void OpenMessage(
       PopupMessageInfo popupMessageInfo,
        Action cancleACtion,
        Action okAction
    )
    {
        this.popupMessageInfo = popupMessageInfo;
        this.cancleACtion = cancleACtion;
        this.okAction = okAction;

        this.textTitle.text = popupMessageInfo.title;
        this.contentTitle.text = popupMessageInfo.message;
    }

    public void OnClick_Cancle()
    {
        cancleACtion?.Invoke();
    }

    public void OnClick_Ok()
    {
        okAction?.Invoke();
    }
}
