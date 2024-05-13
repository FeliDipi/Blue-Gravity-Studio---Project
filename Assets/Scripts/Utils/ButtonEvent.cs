using UnityEngine.Events;

public class ButtonEvent : ButtonAnimation
{
    public UnityEvent OnClick;

    public override void Click()
    {
        OnClick?.Invoke();
    }
}
