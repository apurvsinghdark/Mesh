using TMPro;

public class OnClickChangeText : ClickToAction
{
    public TMP_Text text;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        if(!animator.GetBool(animationName))
        {
            text.text = "Click on the workpiece to load the job into the chuck";
        }else if(animator.GetBool(animationName))
        {
            text.text = "Press program list button";
        }
    }
}
