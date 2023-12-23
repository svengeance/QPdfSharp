namespace QPdfSharp.Interop;

[NativeTypeName("unsigned int")]
internal enum PdfAnnotationFlag : uint
{
    an_invisible = 1 << 0,
    an_hidden = 1 << 1,
    an_print = 1 << 2,
    an_no_zoom = 1 << 3,
    an_no_rotate = 1 << 4,
    an_no_view = 1 << 5,
    an_read_only = 1 << 6,
    an_locked = 1 << 7,
    an_toggle_no_view = 1 << 8,
    an_locked_contents = 1 << 9,
}
