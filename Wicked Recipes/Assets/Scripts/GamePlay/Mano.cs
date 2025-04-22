using UnityEngine;

public class Mano : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerInventory.Instance.llaveEspecialObtenida = true; // Asignar la llave especial al inventario
        
        if (PlayerInventory.Instance != null)
        {
            PlayerInventory.Instance.llaveEspecialObtenida = true;
            Debug.Log("Recolectaste la llave especial.");
            DialogoUI.Instance.MostrarDialogo("Recolectaste una llave misteriosa... parece importante.");
        }
    }
}
