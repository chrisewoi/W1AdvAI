using UnityEngine;

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
    }

    void Update()
    {
        float scoreTotal = 0f;
        for (int i = 0; i < jointData.Length; i++)
        {
            var joint = jointData[i];
            float newScore = Mathf.Abs(joint.previousForce
                - joint.joint.currentForce.magnitude);

            print(newScore);

            joint.previousForce = joint.joint.currentForce.magnitude;
        }
        print(scoreTotal);
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

    public void Ragdoll()
    {
        animator.enabled = false;
    }
}
