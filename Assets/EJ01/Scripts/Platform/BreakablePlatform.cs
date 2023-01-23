
public class BreakablePlatform : Platform
{
    public override void PlatformAction()
    {
        Destroy(gameObject);
    }
}
