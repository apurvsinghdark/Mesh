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

    public void IsInserted()
    {
        if(!animator.GetBool(animationName))
        {
            text.text = "Press program list button";
            animator.SetBool(animationName,true);
        }
    }
    public void IsInsertedOut()
    {
        if(animator.GetBool(animationName))
        {
            text.text = "Click on the Start Cycle";
            // text.text = "Click on the workpiece to load the job into the chuck";
            animator.SetBool(animationName,false);
        }
    }
}
