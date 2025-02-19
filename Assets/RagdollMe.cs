using UnityEngine;
using UnityEngine.Rendering;

public struct JointData
{
    public Joint joint;
    public float previousForce;

    public JointData(Joint newJoint)
    {
        this.joint = newJoint;
        previousForce = 0f;
    }
}

public class RagdollMe : MonoBehaviour
{
    public Animator animator;
    JointData[] jointData;

    void Start()
    {
        animator = GetComponent<Animator>();

        GetAllJoints();
        AddChildRagdoll();
        SetChildColliders(false);
    }

    void Update()
    {
        float scoreTotal = 0f;
        for (int i = 0; i < jointData.Length; i++)
        {
            var joint = jointData[i];
            float newScore = Mathf.Abs(joint.previousForce
                - joint.joint.currentForce.magnitude);

            //print(newScore);
            scoreTotal += newScore;

            joint.previousForce = joint.joint.currentForce.magnitude;
        }
        //print(scoreTotal);
    }

    void GetAllJoints()
    {
        Joint[] joints = GetComponentsInChildren<Joint>();
        jointData = new JointData[joints.Length];

        for (int i = 0; i < jointData.Length; i++)
        {
            Joint joint = joints[i];
            jointData[i] = new JointData(joint);
        }
    }

    void AddChildRagdoll()
    {
        foreach(var rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.gameObject.AddComponent<ChildRagdoll>();
            if (rb.gameObject != gameObject)
            {
                rb.isKinematic = true;
            }
        }
    }

    void SetChildColliders(bool enabled)
    {
        Collider currentCol = GetComponent<Collider>();
        foreach (var col in GetComponentsInChildren<Collider>())
        {
            if(col == currentCol)
            {
                currentCol.enabled = !enabled;
            } else
            {
                col.enabled = enabled;
            }
        }
    }

    public void Ragdoll(Vector3 impact)
    {
        //Debug.Log(impact.magnitude);
        if (impact.magnitude < 10f) return;
        SetChildColliders(true);
        animator.enabled = false;
    }

    void ResetVelocities(Vector3 impulse)
    {
        var rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.isKinematic = false;
            rb.linearVelocity = -impulse / rbs.Length;
            rb.linearVelocity = Vector3.zero;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            Ragdoll(collision.impulse);
        }
    }
}
