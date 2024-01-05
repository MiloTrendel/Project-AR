using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMShowAR : MonoBehaviour
{
    private List<Vector3> Joints;

    public List<Vector3> UpdateJointPositions(bool jointouorientation, SkeletonInfo skeletonInfo)
    {
        Debug.Log("======================================================");
        Joints = new List<Vector3>(21);
        Vector3[] valSkeleton = skeletonInfo.orientation_joints;

        if (jointouorientation) valSkeleton = skeletonInfo.joints;
        Vector3 origin = valSkeleton[0];

        foreach (var field in valSkeleton)
        {
            Vector3 joint = new Vector3(field.x - origin.x, field.y - origin.y, field.z);
            Joints.Add(joint);
            Debug.Log(joint);
        }

        return Joints;
    }
}
