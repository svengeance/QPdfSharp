namespace QPdf.Interop;

[NativeTypeName("unsigned int")]
public enum QPdfObjectType : uint
{
    ot_uninitialized,
    ot_reserved,
    ot_null,
    ot_boolean,
    ot_integer,
    ot_real,
    ot_string,
    ot_name,
    ot_array,
    ot_dictionary,
    ot_stream,
    ot_operator,
    ot_inlineimage,
    ot_unresolved,
    ot_destroyed,
}
