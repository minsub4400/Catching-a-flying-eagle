using UnityEngine;
using UnityEngine.UI;

public class MainCursor : MonoBehaviour
{
    public RectTransform cursorImage;
    void Start()
    {
        Init_Cursor();
    }

    void Update()
    {
        Update_MousePosition();
    }
    private void Init_Cursor()
    {
        Cursor.visible = false;
        cursorImage.pivot = Vector2.up;
        if (cursorImage.GetComponent<Graphic>())
            cursorImage.GetComponent<Graphic>().raycastTarget = false;
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        cursorImage.transform.position = mousePos;
    }
}
