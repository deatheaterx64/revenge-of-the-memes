using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRagdoll : MonoBehaviour
{
    // colliders that needs to be enabled when not using ragdoll
    public Collider[] colliderToEnable;

    // rigidbody that is  activated when not using ragdoll
    public Rigidbody rb;

    // all colliders that are activated when using ragdoll
    public Collider[] allCollider;

    // all the rigidbodies used by ragdoll
    public List<Rigidbody> ragdollRigidBodies;

    // animator used to controll different animation state of the character
    public Animator anim;

    EnemyMovement enemyMovement;

    

    private void Init()
    {
        allCollider = GetComponentsInChildren<Collider>(true); // get all the colliders that are attached
        foreach (var collider in allCollider)
        {
            if (collider.transform != transform) // if this is not parent transform
            {
                var rag_rb = collider.GetComponent<Rigidbody>(); // get attached rigidbody
                if (rag_rb)
                {
                    ragdollRigidBodies.Add(rag_rb); // add to list
                }
            }
        }
        enemyMovement = GetComponent<EnemyMovement>();
    }
    public void EnableRagdoll(bool enableRagdoll)
    {

        if (enableRagdoll)
        {
            Destroy(gameObject, 7f);

            enemyMovement.StopAllCoroutines();
            enemyMovement.enabled = false;
        }
        if(anim != null)
            anim.enabled = !enableRagdoll;
        foreach (Collider item in allCollider)
        {
            item.enabled = enableRagdoll; // enable all colliders  if ragdoll is set to enabled
        }

        foreach (var ragdollRigidBody in ragdollRigidBodies)
        {
            ragdollRigidBody.useGravity = enableRagdoll; // make rigidbody use gravity if ragdoll is active
            ragdollRigidBody.isKinematic = !enableRagdoll; // enable or disable kinematic accordig to enableRagdoll variable
        }

        foreach (Collider item in colliderToEnable)
        {
            item.enabled = !enableRagdoll; // flip the normal colliders active state
        }
        rb.useGravity = !enableRagdoll; // normal rigidbody dont use gravity when ragdoll is active
        rb.isKinematic = enableRagdoll;
    }

    private void Start()
    {
        Init();
        EnableRagdoll(false);
    }

    
}
