using UnityEngine;

public class Florero : MonoBehaviour
{
    public Sprite floreroRotoSprite;
    private SpriteRenderer sr;
    private int toques = 0;
    private bool roto = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (roto) return;

        toques++;

        if (toques >= 4)
        {
            RomperFlorero();
        }
    }

    void RomperFlorero()
    {
        roto = true;
        sr.sprite = floreroRotoSprite;

        DialogoUI.Instance.EscribirTexto("¡Se rompió el florero! Había una llave dentro.", 0.03f);

        PlayerInventory.Instance.tieneLlave = true;
    }
}
