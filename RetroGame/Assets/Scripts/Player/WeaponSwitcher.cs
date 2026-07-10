using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] availableAxes;
    public PlayerPickup pickupScript;
    private int currentAxeIndex = 0; 
    public void SwitchWeapon(int index)
    {
        availableAxes[currentAxeIndex].SetActive(false);
        availableAxes[index].SetActive(true);
        currentAxeIndex = index;
        pickupScript.currentActiveAxe = availableAxes[index];
    }
}