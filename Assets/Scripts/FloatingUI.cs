using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    public float moveAmount = 10f; // Qué tanto se mueve en píxeles
    public float moveSpeed = 1f;   // Velocidad del movimiento

    private RectTransform rectTransform;
    private Vector2 startPos;
    private float offsetX;
    private float offsetY;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;

        // Desfase aleatorio para que no se muevan igual
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
    }

    void Update()
    {
        float x = Mathf.PerlinNoise(Time.time * moveSpeed + offsetX, 0f) - 0.5f;
        float y = Mathf.PerlinNoise(0f, Time.time * moveSpeed + offsetY) - 0.5f;

        rectTransform.anchoredPosition = startPos + new Vector2(x, y) * moveAmount;
    }
}
