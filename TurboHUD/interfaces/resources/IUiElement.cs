namespace Turbo.Plugins
{

    public interface IUiElement
    {

        bool Visible { get; }
        System.Drawing.RectangleF Rectangle { get; }

    }

}
