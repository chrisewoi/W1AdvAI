using UnityEngine;

public class ChildRagdoll : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        return;
        RagdollMe other = collision.gameObject.GetComponentInParent<RagdollMe>();
        RagdollMe self = GetComponentInParent<RagdollMe>();

       // Debug.Log(collision.gameObject.layer);
       // print(LayerMask.NameToLayer("Ground"));

        if (self != null && other != self && collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            print(collision.gameObject.name);
            self.Ragdoll(collision.relativeVelocity);
            enabled = false;
        }


        //GetComponentInParent<RagdollMe>()?.Ragdoll();
        
    }
}
