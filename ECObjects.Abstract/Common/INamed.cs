namespace ECObjects.Abstract.Common
{
    public interface INamed
    {
        string Name { get; set; }
        string? DisplayLabel { get; set; }
        bool IsDisplayLabelDefined { get; }
    }
}