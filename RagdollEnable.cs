using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnable : MonoBehaviour
{
    [SerializeField] public GameObject[] bones;

    [SerializeField] Animator CharacterAnimator;

    [SerializeField] public bool enableRagdoll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enableRagdoll == true)
        {
            for(int i = 0; i < bones.Length; i++)
            {
                bones[i].GetComponent<Rigidbody>().isKinematic = false;
                CharacterAnimator.enabled = false;
            }
        }

        if (enableRagdoll == false)
        {
            for (int i = 0; i < bones.Length; i++)
            {
                bones[i].GetComponent<Rigidbody>().isKinematic = true;
                CharacterAnimator.enabled = true;
            }
        }
    }
}
