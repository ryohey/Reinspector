using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class TextSerializable : MaskableGraphicSerializable
    {
        public TextAnchor alignment;
        public bool alignByGeometry;
        public int fontSize;
        public HorizontalWrapMode horizontalOverflow;
        public VerticalWrapMode verticalOverflow;
        public float lineSpacing;
        public int resizeTextMaxSize;
        public FontStyle fontStyle;
        public int resizeTextMinSize;
        public bool supportRichText;
        public bool resizeTextForBestFit;
        public FontSerializable font;
        public string text;

        public TextSerializable() : base() { }

        public TextSerializable(Text text) : base(text)
        {
            alignment = text.alignment;
            alignByGeometry = text.alignByGeometry;
            fontSize = text.fontSize;
            horizontalOverflow = text.horizontalOverflow;
            verticalOverflow = text.verticalOverflow;
            lineSpacing = text.lineSpacing;
            resizeTextMaxSize = text.resizeTextMaxSize;
            fontStyle = text.fontStyle;
            resizeTextMinSize = text.resizeTextMinSize;
            supportRichText = text.supportRichText;
            resizeTextForBestFit = text.resizeTextForBestFit;
            font = text.font != null ? new FontSerializable(text.font) : null;
            this.text = text.text;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var text = component as Text;

            text.alignment = alignment;
            text.alignByGeometry = alignByGeometry;
            text.fontSize = fontSize;
            text.horizontalOverflow = horizontalOverflow;
            text.verticalOverflow = verticalOverflow;
            text.lineSpacing = lineSpacing;
            text.resizeTextMaxSize = resizeTextMaxSize;
            text.fontStyle = fontStyle;
            text.resizeTextMinSize = resizeTextMinSize;
            text.supportRichText = supportRichText;
            text.resizeTextForBestFit = resizeTextForBestFit;
            text.font = font?.Instantiate();
            text.text = this.text;
        }
    }
}
