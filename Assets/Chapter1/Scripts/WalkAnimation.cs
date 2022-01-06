using UnityEngine;

public class WalkAnimation : MonoBehaviour
{
    public bool isWalkingAtStart = true;

    private void Start()
    {
        GetComponent<Animator>().SetBool("walk", isWalkingAtStart);
    }

    public void SetWalk(bool isWalking)
    {
        GetComponent<Animator>().SetBool("walk", isWalking);
    }
}
