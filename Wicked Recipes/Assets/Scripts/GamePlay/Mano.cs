using UnityEngine;

public class Mano : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerInventory.Instance.llaveEspecialObtenida = true; // Asignar la llave especial al inventario
        
        if (PlayerInventory.Instance != null)
        {
            //desactivar el objeto
            gameObject.SetActive(false); // Desactivar el objeto de la escena
            PlayerInventory.Instance.llaveEspecialObtenida = true;
            Debug.Log("Recolectaste la llave especial.");
            DialogoUI.Instance.EscribirTexto("Recolectaste una llave misteriosa... parece importante.", 0.03f);
        }
    }
}
