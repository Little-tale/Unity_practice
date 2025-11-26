using UnityEngine;

public class TestForPopuip : MonoBehaviour
{
    [SerializeField] GameObject prefabPopupMessage;
    [SerializeField] Transform parenPopupMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gameObject = Instantiate(prefabPopupMessage, parenPopupMessage);
        PopupMessage popupMessage = gameObject.GetComponent<PopupMessage>();
        
        PopupMessageInfo popupMessageInfo = new PopupMessageInfo(title: "hi", message: "hello");
        popupMessage.OpenMessage(popupMessageInfo, GoUpdate, CancleUpdate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GoUpdate() { }

    private void CancleUpdate() { }
}
