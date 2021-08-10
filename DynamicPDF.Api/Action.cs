namespace DynamicPDF.Api
{
    /// <summary>
    /// Base class representing an action to perform tasks in many places 
    /// such as in outlines, links, buttons etc.
    /// </summary>
    /// <remarks><see cref="UrlAction"/> and <see cref="GoToAction"/> are derived from Action.
    public abstract class Action
    {
        internal Action() { }
    }
}
