using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GMShowAR : GMBaseState
{
    private List<Vector3> Joints;

    public GMShowAR(GameStateContext context, GameStateManager.EGameStates key) : base(context, key)
    {
        GameStateContext Context = context;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter ShowAR");
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update ShowAR");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return nextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit ShowAR");
        nextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG functon called");
        nextStateKey = GameStateManager.EGameStates.MainMenu;
    }

    public List<Vector3> GetLastHandPos(bool jointouorientation, SkeletonInfo skeletonInfo)
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

    public void TrySpells(List<Spell> spells)
    {

    }

    public void DrawSpells(List<Spell> spells)
    {

    }
}
