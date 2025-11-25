using UnityEngine;

public class ReSolution : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        var camera = GetComponent<Camera>();
        var rect = camera.rect;
        var scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        var sclaeWidth = 1f / scaleHeight; // 1 : 1

        if (scaleHeight < 1f)
        {
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1f - scaleHeight) / 2f;
        }
        else
        {
            rect.width = sclaeWidth;
            rect.height = 1f;
            rect.x = (1f - sclaeWidth) / 2f;
            rect.y = 0;
        }
        camera.rect = rect;
    }
}
