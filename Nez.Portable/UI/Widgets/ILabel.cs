namespace Nez.UI
{
    public interface ILabel
    {
        ILabel SetText(string text);
        ILabel SetStyle(LabelStyle labelStyle);
        ILabel SetAlignment(Align alignment);
        LabelStyle GetStyle();
		string GetText();
	}
}