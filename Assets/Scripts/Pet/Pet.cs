using System;
using UnityEditor.Animations;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private PetStats stats;
    private AnimatorController _animator;
    private Aquarium _aquarium;

    private void Awake()
    {
        _animator = GetComponent<AnimatorController>();
        _aquarium = GameObject.Find("Fondo").GetComponent<Aquarium>();//busca el GameObject acua
    }

    public void GetAction(Action action)
    {
        //ejecutar accion en la animación 
        //subir estadisticas
    }

    public void ChangeMood(Mood mood)
    {
        //cambiar aimacion dependiendo del estado de animo
        //animacion dormir
    }

    public void Eat(int points)
    {
        //añadir puntos al nivel de saciedad
        //animacion dormir
    }

    public void Sleep(int points)
    {
        //añadir puntos de sueño
        //animacion dormir
    }
}