/*

This is a super basic Door open and close system.

The script needs to be in your character and the door you want to open
needs to have a trigger collider and a tag.

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    //Public
    public KeyCode openBind;
    public bool autoOpen = false;
    [Space(20)] // 20 pixels
    public string doorTag;
    [Space(20)] // 20 pixels
    public float animationTime;
    [Space(5)] // 5 pixels
    public string openAnimation;
    public string closeAnimation;
    [Space(20)] // 20 pixels
    public float soundDelay;
    [Space(5)] // 5 pixels
    public AudioSource openSound;
    public AudioSource closeSound;


    //Private
    private bool flank = false;
    private GameObject doorObject;
    private bool isOpenCheck = false;
    private DoorState state;



    //Checks if the door should open or should close when you press E
    void Update()
    {
        if (Input.GetKeyDown(openBind) && flank && state.isOpen == false)
        {
            Debug.Log("Open");
            state.isOpen = true;
            doorOpen();
        }
        
        if (Input.GetKeyDown(openBind) && flank && state.isOpen == true)
        {
            Debug.Log("Close");
            state.isOpen = false;
            doorClose();
        }
            
    }



    //The methods that gets calld everytime you are opening and closing the door
    void doorOpen()
    {
        Animator x = doorObject.GetComponent<Animator>();
        BoxCollider y = doorObject.GetComponent<BoxCollider>();
        y.enabled = false;
        x.Play(openAnimation);
        StartCoroutine(ColissionDelay(soundDelay, true));
        StartCoroutine(ColissionDelay(animationTime, y));
    }
    void doorClose()
    {
        Animator x = doorObject.GetComponent<Animator>();
        BoxCollider y = doorObject.GetComponent<BoxCollider>();
        y.enabled = false;
        x.Play(closeAnimation);
        StartCoroutine(ColissionDelay(soundDelay, false));
        StartCoroutine(ColissionDelay(animationTime, y));
    }




    //checks if you are in the trigger
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == doorTag)
        {
            doorObject = collision.gameObject;
            if (autoOpen == false)
            {
                state = doorObject.GetComponent<DoorState>();
                flank = true;
            }
            if (autoOpen == true)
            {
                doorOpen();
            }
        }   
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == doorTag)
        {
            doorObject = collision.gameObject;
            if (autoOpen == false)
            {
                flank = false;
            }
            if (autoOpen == true)
            {
                doorClose();
            }
        }   
    }




    //sound and collision opening delay
    IEnumerator ColissionDelay(float time, bool y)
    {
        yield return new WaitForSeconds(time);

        if(y==true)
            openSound.Play();
        if(y==false)
            closeSound.Play();
    }
    IEnumerator ColissionDelay(float time, BoxCollider y)
    {
        yield return new WaitForSeconds(time);
        
        y.enabled = true;
    }
}
