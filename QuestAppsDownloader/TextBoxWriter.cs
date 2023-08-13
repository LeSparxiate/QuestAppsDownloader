using System.Text;

namespace QuestAppsDownloader;

public class TextBoxWriter : TextWriter
{
    RichTextBox _output = null;

    public TextBoxWriter(RichTextBox output)
    {
        _output = output;
    }

    public override void Write(char value)
    {
        base.Write(value);
        _output.AppendText(value.ToString());
    }

    public override Encoding Encoding
    {
        get { return Encoding.UTF8; }
    }
}
