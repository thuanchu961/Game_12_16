using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SetAnimationController : MonoBehaviour, ISetAnimation
{
    public void SetAnim(string name, GameObject gameObject, bool loop)
    {
        SkeletonAnimation skeletonAnimation = gameObject.GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationState.SetAnimation(0, name, loop);
    }
}
