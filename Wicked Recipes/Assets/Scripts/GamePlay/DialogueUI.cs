using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    public static DialogoUI Instance;

    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        OcultarDialogo();
    }

    public void MostrarDialogo(string mensaje)
    {
        if (!string.IsNullOrEmpty(mensaje))
        {
            panelDialogo.SetActive(true);
            textoDialogo.text = mensaje;
            CancelInvoke(nameof(OcultarDialogo));
            Invoke(nameof(OcultarDialogo), 3f); // El mensaje se oculta después de 3 segundos
        }
    }

    public void OcultarDialogo()
    {
        panelDialogo.SetActive(false);
        textoDialogo.text = "";
    }
}
