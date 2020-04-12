using Microsoft.Xna.Framework;

namespace Nez.UI
{
    public interface ILabel
    {
        ILabel SetText(string text);
        ILabel SetStyle(LabelStyle labelStyle);
        LabelStyle GetStyle();
		string GetText();
        ILabel SetAlignment(Align alignment);
        ILabel SetFontColor(Color color);

		Element Element { get; }
   	}
}