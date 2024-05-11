using System;

public class ButtonEvent : ButtonAnimation
{
    public Action OnClick;

    public override void Click()
    {
        OnClick?.Invoke();
    }
}
