using UnityEngine;

public class Placewood : MonoBehaviour
{
    public string Wood;
    public GameObject[] woodStages;
    private int currentStage = 0;

    public bool TryPlace(GameObject heldObject)
    {
        PickUpItem item = heldObject.GetComponent<PickUpItem>();
        if (item != null && item.itemName == Wood && currentStage < woodStages.Length)
        {
            woodStages[currentStage].SetActive(true);
            currentStage++;
            return true;
        }
        return false;
    }
}