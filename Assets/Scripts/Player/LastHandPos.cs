using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LastHandPos : MonoBehaviour
{

    private List<Vector3> Joints;
    public List<Vector3> perfectHand = new List<Vector3>() {
        new Vector3(0,0,0),
        new Vector3(-0.09f, 0.08f, -0.07f),
        new Vector3(-0.17f, 0.15f, -0.09f),
        new Vector3(-0.21f, 0.22f, -0.13f),
        new Vector3(-0.22f, 0.30f, -0.17f),
        new Vector3(-0.13f, 0.29f, 0.13f),
        new Vector3(-0.19f, 0.32f, 0.06f),
        new Vector3(-0.21f, 0.31f, -0.04f),
        new Vector3(-0.22f, 0.27f, -0.09f),
        new Vector3(-0.10f, 0.34f, 0.11f),
        new Vector3(-0.13f, 0.43f, 0.11f),
        new Vector3(-0.16f, 0.49f, 0.05f),
        new Vector3(-0.18f, 0.56f, 0.00f),
        new Vector3(-0.06f, 0.36f, 0.06f),
        new Vector3(-0.08f, 0.44f, 0.06f),
        new Vector3(-0.10f, 0.50f, 0.02f),
        new Vector3(-0.11f, 0.58f, -0.01f),
        new Vector3(-0.03f, 0.33f, -0.02f),
        new Vector3(-0.03f, 0.39f, -0.03f),
        new Vector3(-0.02f, 0.45f, -0.05f),
        new Vector3(-0.02f, 0.49f, -0.07f),
    };

    public List<Vector3> UpdateJointPositions(bool jointouorientation, SkeletonInfo skeletonInfo)
    {
        Debug.Log("======================================================");
        Joints = new List<Vector3>(21);
        Vector3[] valSkeleton = skeletonInfo.orientation_joints;

        if (jointouorientation) valSkeleton = skeletonInfo.joints;
        Vector3 origin = valSkeleton[0];

        int x = 0;
        foreach (var field in valSkeleton)
        {
            Vector3 joint = new Vector3(field.x - origin.x, field.y - origin.y, field.z);
            Joints.Add(joint);
            Debug.Log(x + " : " + joint);
            x++;
        }

        return Joints;
    }

    public bool TrySpells(List<Vector3> Spell, List<Vector3> handPos)
    {
        int similar = 0;
        for (int i = 0; i < 21; i++)
        {
            int pointSimilar = 0;
            for (int y = 0; y < 3; y++)
            {
                if (Spell[i][y] > handPos[i][y] - 0.05 && Spell[i][y] < handPos[i][y] + 0.05)
                {
                    pointSimilar++;
                }
            }
            if (pointSimilar >= 3)  similar++;
        }
        if (similar > 17)
        {
            Application.Quit();
            return true;
        }
        else
        {
            return false;
        }
    }
}