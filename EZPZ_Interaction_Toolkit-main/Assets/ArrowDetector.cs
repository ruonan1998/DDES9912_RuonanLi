using UnityEngine;

public class ArrowDetector : MonoBehaviour
{
    public SlotMachineWheels wheel;

    private void OnTriggerEnter(Collider other)
    {
        FruitImage img = other.GetComponent<FruitImage>();
        if (img != null)
        {
            wheel.lastFruitName = img.fruitName;
            Debug.Log("Detected Fruit: " + img.fruitName);
        }
    }
}