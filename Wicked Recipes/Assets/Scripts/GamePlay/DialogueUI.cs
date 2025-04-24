using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    public static DialogoUI Instance;

    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;

    private Coroutine escribiendo;
    private bool textoCompleto = false;
    private string textoActual = "";

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        OcultarDialogo();
    }

    public void EscribirTexto(string mensaje, float velocidad)
    {
        if (escribiendo != null)
        {
            StopCoroutine(escribiendo);
        }

        panelDialogo.SetActive(true);
        textoActual = mensaje;
        textoDialogo.text = "";
        escribiendo = StartCoroutine(MostrarComoMaquina(mensaje, velocidad));
    }

    IEnumerator MostrarComoMaquina(string mensaje, float velocidad)
    {
        textoCompleto = false;
        foreach (char letra in mensaje)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidad);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                textoDialogo.text = mensaje;
                break;
            }
        }

        textoCompleto = true;

        // Espera a que el jugador presione para continuar
        yield return new WaitUntil(() => 
            Input.GetKeyDown(KeyCode.Space) || 
            Input.GetKeyDown(KeyCode.Return) || 
            Input.GetMouseButtonDown(0)
        );

        OcultarDialogo();
    }

    public void OcultarDialogo()
    {
        panelDialogo.SetActive(false);
        textoDialogo.text = "";
        textoCompleto = false;
    }
}
