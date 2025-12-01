using UnityEngine;

public class Opendoor: MonoBehaviour

{   
    public Animator animator1;
    public Animator animator2;
    public Collider door1collider;
    public Collider door2collider;

    void OpenDoor()
   {
    animator1.SetTrigger("OpenDoor1");
    animator2.SetTrigger("OpenDoor2");

    door1collider.enabled = false;
    door2collider.enabled = false;
   }

    void CloseDoor()
   {
    animator1.SetTrigger("CloseDoor1");
    animator2.SetTrigger("CloseDoor2");

    door1collider.enabled = true;
    door2collider.enabled = true;
   }
}