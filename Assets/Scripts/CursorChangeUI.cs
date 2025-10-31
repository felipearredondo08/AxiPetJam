using UnityEngine;
using UnityEngine.EventSystems; // Necesario para IPointerEnterHandler / ExitHandler

public class CursorChangeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D cursorTexture; // Asigna tu textura en el inspector
    [SerializeField] private Vector2 cursorHotspot;   // Ajusta el punto de clic del cursor

    // Cuando el puntero entra en el botón o imagen
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

    // Cuando el puntero sale del botón o imagen
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
