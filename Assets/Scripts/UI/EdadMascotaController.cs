using UnityEngine;
using TMPro;
using System.Collections;

public class EdadMascotaController : MonoBehaviour
{
    [Header("Referencias")]
    public TextMeshProUGUI edadText;
    public GameObject mascotaSprite;

    [Header("Configuración")]
    [Tooltip("Tiempo en minutos para aumentar la edad en 1")]
    [Range(0.1f, 10f)]
    public float tiempoParaEnvejecer = 5f;
    [Tooltip("Tiempo en segundos para pruebas rápidas (0 = desactivado)")]
    [Range(0f, 30f)]
    public float tiempoParaPruebas = 0f;
    [Tooltip("Edad inicial de la mascota")]
    public int edadInicial = 0;
    [Tooltip("Escala máxima permitida")]
    public int escalaMaxima = 25;

    [Header("Depuración")]
    [Tooltip("Marca esta casilla para reiniciar la edad y escala al iniciar el juego.")]
    public bool resetearDatosAlIniciar = false;

    private int edadActual;
    private float tiempoTranscurrido = 0f;

    private void Awake()
    {
        if (resetearDatosAlIniciar)
        {
            PlayerPrefs.DeleteKey("EdadMascota");
            PlayerPrefs.DeleteKey("TiempoTranscurrido");
            PlayerPrefs.Save();
            Debug.Log("Datos de la mascota reseteados.");
        }
    }

    private void Start()
    {
        CargarEdadGuardada();
        ActualizarTextoEdad();
        ActualizarEscalaSegunEdad();
        StartCoroutine(GuardarPeriodicamente());
    }

    private void Update()
    {
        float tiempoAUsar = tiempoParaPruebas > 0 ? tiempoParaPruebas : tiempoParaEnvejecer * 60f;
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoAUsar)
        {
            edadActual++;
            ActualizarTextoEdad();
            ActualizarEscalaSegunEdad();
            tiempoTranscurrido = 0f;
        }
    }

    private void ActualizarTextoEdad()
    {
        if (edadText != null)
        {
            edadText.text = edadActual.ToString();
        }
    }

    private void ActualizarEscalaSegunEdad()
    {
        if (mascotaSprite != null)
        {
            int nuevaEscala = Mathf.Min(15 + edadActual, escalaMaxima);
            mascotaSprite.transform.localScale = new Vector3(nuevaEscala, nuevaEscala, mascotaSprite.transform.localScale.z);
        }
    }

    private void CargarEdadGuardada()
    {
        edadActual = PlayerPrefs.GetInt("EdadMascota", edadInicial);
        tiempoTranscurrido = PlayerPrefs.GetFloat("TiempoTranscurrido", 0f);
    }

    private void GuardarDatos()
    {
        PlayerPrefs.SetInt("EdadMascota", edadActual);
        PlayerPrefs.SetFloat("TiempoTranscurrido", tiempoTranscurrido);
        PlayerPrefs.Save();
    }
    
    private IEnumerator GuardarPeriodicamente()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            GuardarDatos();
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            GuardarDatos();
        }
    }

    private void OnApplicationQuit()
    {
        GuardarDatos();
    }
}