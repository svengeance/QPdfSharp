namespace QPdfSharp.Enums;

public enum PdfAnnotationFlag : uint
{
    AInvisible = 1 << 0,
    AHidden = 1 << 1,
    APrint = 1 << 2,
    ANoZoom = 1 << 3,
    ANoRotate = 1 << 4,
    ANoView = 1 << 5,
    AReadOnly = 1 << 6,
    ALocked = 1 << 7,
    AToggleNoView = 1 << 8,
    ALockedContents = 1 << 9,
}
