
using System;
using UnityEngine;

public class Levelchanger : MonoBehaviour
{
 public Animator animator;

   

    private void FadeToLevel(int v)
    {
        throw new NotImplementedException();
    }

    public void FadeToLevel(string levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
}
