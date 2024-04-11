using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EventTest : PuzzleManager
{
    public Door door;
    private bool solved;

    private void Start()
    {
        solved = false;
    }

    public void SelectEntered(SelectEnterEventArgs e) => Display("select entered", e);
    public void SelectExited(SelectExitEventArgs e) => Display("select exited", e);

    public void Activated(ActivateEventArgs e) => Display("activated", e);
    public void Deactivated(DeactivateEventArgs e) => Display("deactivated", e);

    public void Display(string text, BaseInteractionEventArgs e)
    {
        if (text == "select exited" && solved == false)
        {
            door.ChangeState(DoorStateType.OPENING);
            // SoundManager.Instance.Play(SoundType.LEVER);
            solved = true;
        }

    }

    public override bool VerifySolved()
    {
        return solved;
    }
}
