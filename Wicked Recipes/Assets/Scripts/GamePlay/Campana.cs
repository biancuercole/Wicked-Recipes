using UnityEngine;

public class Campana : MonoBehaviour
{
    public GameObject mano; // Asignalo desde el Inspector
    private int toques = 0;
    private bool activada = false;

    void Start()
    {
        if (mano != null)
            mano.SetActive(false); // Oculta la mano al inicio
    }

    void OnMouseDown()
    {
        if (activada) return;

        toques++;
        Debug.Log("Campana tocada: " + toques + " veces");

        if (toques >= 6)
        {
            ActivarMano();
        }
    }

    void ActivarMano()
    {
        activada = true;
        if (mano != null)
        {
            mano.SetActive(true);
            Debug.Log("¡La mano apareció!");
        }
    }
}
