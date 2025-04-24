using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BakingMinigame : MonoBehaviour
{
    [Header("Referencias UI")]
    public RectTransform cursor;
    public RectTransform zonaVerde;
    public GameObject hornoUI;
    public TextMeshProUGUI mensajeFinal;
    public Button cerrarBoton;
    public GameObject victorySprite;

    [Header("Configuración")]
    public float velocidad = 400f;
    public int intentosTotales = 3;

    private bool moviendoDerecha = true;
    private int intentosExitosos = 0;
    private float anchoOriginalZonaVerde;
    private bool jugando = false;

    void Start()
    {
        cerrarBoton.onClick.AddListener(CerrarMinijuego);
        anchoOriginalZonaVerde = zonaVerde.sizeDelta.x;
        mensajeFinal.gameObject.SetActive(false);
        hornoUI.SetActive(false);
    }

    public void IniciarMinijuego()
    {
        intentosExitosos = 0;
        zonaVerde.sizeDelta = new Vector2(anchoOriginalZonaVerde, zonaVerde.sizeDelta.y);
        cursor.anchoredPosition = new Vector2(-zonaVerde.parent.GetComponent<RectTransform>().rect.width / 2, cursor.anchoredPosition.y);
        hornoUI.SetActive(true);
        mensajeFinal.gameObject.SetActive(false);
        jugando = true;
    }

    void Update()
    {
        if (!jugando) return;

        MoverCursor();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            VerificarAcierto();
        }
    }

    void MoverCursor()
    {
        float limiteIzq = -zonaVerde.parent.GetComponent<RectTransform>().rect.width / 2 + cursor.rect.width / 2;
        float limiteDer = zonaVerde.parent.GetComponent<RectTransform>().rect.width / 2 - cursor.rect.width / 2;

        float delta = velocidad * Time.deltaTime * (moviendoDerecha ? 1 : -1);
        float nuevaX = cursor.anchoredPosition.x + delta;

        if (nuevaX >= limiteDer)
        {
            nuevaX = limiteDer;
            moviendoDerecha = false;
        }
        else if (nuevaX <= limiteIzq)
        {
            nuevaX = limiteIzq;
            moviendoDerecha = true;
        }

        cursor.anchoredPosition = new Vector2(nuevaX, cursor.anchoredPosition.y);
    }

    void VerificarAcierto()
    {
        float distancia = Mathf.Abs(cursor.anchoredPosition.x - zonaVerde.anchoredPosition.x);
        float mitadVerde = zonaVerde.sizeDelta.x / 2;

        if (distancia <= mitadVerde)
        {
            intentosExitosos++;
            Debug.Log("¡Acierto!");

            if (intentosExitosos >= intentosTotales)
            {
                victorySprite.SetActive(true);
                mensajeFinal.text = "¡Ganaste!";
                mensajeFinal.gameObject.SetActive(true);
                jugando = false;
            }
            else
            {
                float nuevoAncho = zonaVerde.sizeDelta.x * 0.6f;
                zonaVerde.sizeDelta = new Vector2(nuevoAncho, zonaVerde.sizeDelta.y);
            }
        }
        else
        {
            Debug.Log("Fallaste");
        }
    }

    void CerrarMinijuego()
    {
        hornoUI.SetActive(false);
        jugando = false;
    }
}
