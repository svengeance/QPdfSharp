using System;
using System.Runtime.InteropServices;

namespace QPdf.Interop;

public static unsafe partial class QPdfInterop
{
    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_silence_errors([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_qpdf_version();

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_data")]
    public static extern QPdfData* qpdf_init();

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_cleanup([NativeTypeName("qpdf_data *")] QPdfData** qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_has_error([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_error")]
    public static extern QPdfError* qpdf_get_error([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_more_warnings([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_error")]
    public static extern QPdfError* qpdf_next_warning([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_error_full_text([NativeTypeName("qpdf_data")] QPdfData* q, [NativeTypeName("qpdf_error")] QPdfError* e);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum qpdf_error_code_e")]
    public static extern QPdfErrorCode qpdf_get_error_code([NativeTypeName("qpdf_data")] QPdfData* q, [NativeTypeName("qpdf_error")] QPdfError* e);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_error_filename([NativeTypeName("qpdf_data")] QPdfData* q, [NativeTypeName("qpdf_error")] QPdfError* e);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned long long")]
    public static extern ulong qpdf_get_error_file_position([NativeTypeName("qpdf_data")] QPdfData* q, [NativeTypeName("qpdf_error")] QPdfError* e);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_error_message_detail([NativeTypeName("qpdf_data")] QPdfData* q, [NativeTypeName("qpdf_error")] QPdfError* e);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_suppress_warnings([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_logger([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* logger);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdflogger_handle")]
    public static extern QPdfLoggerHandle* qpdf_get_logger([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_check_pdf([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_ignore_xref_streams([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_attempt_recovery([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_read([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* password);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_read_memory([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* description, [NativeTypeName("const char *")] sbyte* buffer, [NativeTypeName("unsigned long long")] ulong size, [NativeTypeName("const char *")] sbyte* password);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_empty_pdf([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_create_from_json_file([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* filename);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_create_from_json_data([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* buffer, [NativeTypeName("unsigned long long")] ulong size);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_update_from_json_file([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* filename);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_update_from_json_data([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* buffer, [NativeTypeName("unsigned long long")] ulong size);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_pdf_version([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_get_pdf_extension_level([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_user_password([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_get_info_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* key);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_info_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_is_linearized([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_is_encrypted([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_accessibility([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_extract_all([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_print_low_res([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_print_high_res([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_modify_assembly([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_modify_form([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_modify_annotation([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_modify_other([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_allow_modify_all([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_write_json([NativeTypeName("qpdf_data")] QPdfData* qpdf, int version, [NativeTypeName("qpdf_write_fn_t")] QPdfWriteFunction fn, void* udata, [NativeTypeName("enum qpdf_stream_decode_level_e")] QPdfStreamDecodeLevel decode_level, [NativeTypeName("enum qpdf_json_stream_data_e")] QPdfJsonStreamData json_stream_data, [NativeTypeName("const char *")] sbyte* file_prefix, [NativeTypeName("const char *const *")] sbyte** wanted_objects);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_init_write([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* filename);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_init_write_memory([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern UIntPtr qpdf_get_buffer_length([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const unsigned char *")]
    public static extern byte* qpdf_get_buffer([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_object_stream_mode([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("enum qpdf_object_stream_e")] QPdfObjectStream mode);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_stream_data_mode([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("enum qpdf_stream_data_e")] QPdfStreamData mode);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_compress_streams([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_decode_level([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("enum qpdf_stream_decode_level_e")] QPdfStreamDecodeLevel level);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_preserve_unreferenced_objects([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_newline_before_endstream([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_content_normalization([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_qdf_mode([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_deterministic_ID([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_static_ID([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_static_aes_IV([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_suppress_original_object_IDs([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_preserve_encryption([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_r2_encryption_parameters_insecure([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* user_password, [NativeTypeName("const char *")] sbyte* owner_password, [NativeTypeName("QPDF_BOOL")] int allow_print, [NativeTypeName("QPDF_BOOL")] int allow_modify, [NativeTypeName("QPDF_BOOL")] int allow_extract, [NativeTypeName("QPDF_BOOL")] int allow_annotate);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_r3_encryption_parameters_insecure([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* user_password, [NativeTypeName("const char *")] sbyte* owner_password, [NativeTypeName("QPDF_BOOL")] int allow_accessibility, [NativeTypeName("QPDF_BOOL")] int allow_extract, [NativeTypeName("QPDF_BOOL")] int allow_assemble, [NativeTypeName("QPDF_BOOL")] int allow_annotate_and_form, [NativeTypeName("QPDF_BOOL")] int allow_form_filling, [NativeTypeName("QPDF_BOOL")] int allow_modify_other, [NativeTypeName("enum qpdf_r3_print_e")] QPdfR3Print print);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_r4_encryption_parameters_insecure([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* user_password, [NativeTypeName("const char *")] sbyte* owner_password, [NativeTypeName("QPDF_BOOL")] int allow_accessibility, [NativeTypeName("QPDF_BOOL")] int allow_extract, [NativeTypeName("QPDF_BOOL")] int allow_assemble, [NativeTypeName("QPDF_BOOL")] int allow_annotate_and_form, [NativeTypeName("QPDF_BOOL")] int allow_form_filling, [NativeTypeName("QPDF_BOOL")] int allow_modify_other, [NativeTypeName("enum qpdf_r3_print_e")] QPdfR3Print print, [NativeTypeName("QPDF_BOOL")] int encrypt_metadata, [NativeTypeName("QPDF_BOOL")] int use_aes);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_r5_encryption_parameters2([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* user_password, [NativeTypeName("const char *")] sbyte* owner_password, [NativeTypeName("QPDF_BOOL")] int allow_accessibility, [NativeTypeName("QPDF_BOOL")] int allow_extract, [NativeTypeName("QPDF_BOOL")] int allow_assemble, [NativeTypeName("QPDF_BOOL")] int allow_annotate_and_form, [NativeTypeName("QPDF_BOOL")] int allow_form_filling, [NativeTypeName("QPDF_BOOL")] int allow_modify_other, [NativeTypeName("enum qpdf_r3_print_e")] QPdfR3Print print, [NativeTypeName("QPDF_BOOL")] int encrypt_metadata);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_r6_encryption_parameters2([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* user_password, [NativeTypeName("const char *")] sbyte* owner_password, [NativeTypeName("QPDF_BOOL")] int allow_accessibility, [NativeTypeName("QPDF_BOOL")] int allow_extract, [NativeTypeName("QPDF_BOOL")] int allow_assemble, [NativeTypeName("QPDF_BOOL")] int allow_annotate_and_form, [NativeTypeName("QPDF_BOOL")] int allow_form_filling, [NativeTypeName("QPDF_BOOL")] int allow_modify_other, [NativeTypeName("enum qpdf_r3_print_e")] QPdfR3Print print, [NativeTypeName("QPDF_BOOL")] int encrypt_metadata);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_linearization([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_minimum_pdf_version([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* version);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_set_minimum_pdf_version_and_extension([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* version, int extension_level);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_force_pdf_version([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* version);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_force_pdf_version_and_extension([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* version, int extension_level);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_register_progress_reporter([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("void (*)(int, void *)")] IntPtr report_progress, void* data);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_write([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_release([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_release_all([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_object([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_get_trailer([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_get_root([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_get_object_by_id([NativeTypeName("qpdf_data")] QPdfData* qpdf, int objid, int generation);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_make_indirect_object([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_replace_object([NativeTypeName("qpdf_data")] QPdfData* qpdf, int objid, int generation, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_initialized([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_bool([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_null([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_integer([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_real([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_name([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_operator([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_inline_image([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_array([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_dictionary([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_stream([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_indirect([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_scalar([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_name_and_equals([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* name);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_dictionary_of_type([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* type, [NativeTypeName("const char *")] sbyte* subtype);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum qpdf_object_type_e")]
    public static extern QPdfObjectType qpdf_oh_get_type_code([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_type_name([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_wrap_in_array([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_parse([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* object_str);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_bool_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_bool([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("QPDF_BOOL *")] int* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("long long")]
    public static extern long qpdf_oh_get_int_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_longlong([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("long long *")] long* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_oh_get_int_value_as_int([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_int([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, int* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned long long")]
    public static extern ulong qpdf_oh_get_uint_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_ulonglong([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("unsigned long long *")] ulong* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint qpdf_oh_get_uint_value_as_uint([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_uint([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("unsigned int *")] uint* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_real_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_real([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char **")] sbyte** value, [NativeTypeName("size_t *")] UIntPtr* length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_number([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double qpdf_oh_get_numeric_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_number([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, double* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_name([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_name([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char **")] sbyte** value, [NativeTypeName("size_t *")] UIntPtr* length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern UIntPtr qpdf_get_last_string_length([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_string_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char **")] sbyte** value, [NativeTypeName("size_t *")] UIntPtr* length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_utf8_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_get_value_as_utf8([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char **")] sbyte** value, [NativeTypeName("size_t *")] UIntPtr* length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_binary_string_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("size_t *")] UIntPtr* length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_get_binary_utf8_value([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("size_t *")] UIntPtr* length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_oh_get_array_n_items([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_get_array_item([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, int n);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_begin_dict_key_iter([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint dict);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_dict_more_keys([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_dict_next_key([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_has_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_get_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_get_key_if_dict([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_BOOL")]
    public static extern int qpdf_oh_is_or_has_name([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_uninitialized([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_null([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_bool([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("QPDF_BOOL")] int value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_integer([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("long long")] long value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_real_from_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* value);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_real_from_double([NativeTypeName("qpdf_data")] QPdfData* qpdf, double value, int decimal_places);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_name([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* name);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* str);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_unicode_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* utf8_str);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_binary_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("size_t")] UIntPtr length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_binary_unicode_string([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("size_t")] UIntPtr length);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_array([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_dictionary([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_new_stream([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_make_direct([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_set_array_item([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, int at, [NativeTypeName("qpdf_oh")] uint item);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_insert_item([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, int at, [NativeTypeName("qpdf_oh")] uint item);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_append_item([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("qpdf_oh")] uint item);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_erase_item([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, int at);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_replace_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("qpdf_oh")] uint item);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_remove_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_replace_or_remove_key([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("qpdf_oh")] uint item);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_get_dict([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_oh_get_object_id([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_oh_get_generation([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_unparse([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_unparse_resolved([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* qpdf_oh_unparse_binary([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_oh_copy_foreign_object([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_data")] QPdfData* other_qpdf, [NativeTypeName("qpdf_oh")] uint foreign_oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_oh_get_stream_data([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint stream_oh, [NativeTypeName("enum qpdf_stream_decode_level_e")] QPdfStreamDecodeLevel decode_level, [NativeTypeName("QPDF_BOOL *")] int* filtered, [NativeTypeName("unsigned char **")] byte** bufp, [NativeTypeName("size_t *")] UIntPtr* len);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_oh_get_page_content_data([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint page_oh, [NativeTypeName("unsigned char **")] byte** bufp, [NativeTypeName("size_t *")] UIntPtr* len);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdf_oh_replace_stream_data([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint stream_oh, [NativeTypeName("const unsigned char *")] byte* buf, [NativeTypeName("size_t")] UIntPtr len, [NativeTypeName("qpdf_oh")] uint filter, [NativeTypeName("qpdf_oh")] uint decode_parms);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_get_num_pages([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_oh")]
    public static extern uint qpdf_get_page_n([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("size_t")] UIntPtr zero_based_index);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_update_all_pages_cache([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_find_page_by_id([NativeTypeName("qpdf_data")] QPdfData* qpdf, int objid, int generation);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdf_find_page_by_oh([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint oh);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_push_inherited_attributes_to_page([NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_add_page([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_data")] QPdfData* newpage_qpdf, [NativeTypeName("qpdf_oh")] uint newpage, [NativeTypeName("QPDF_BOOL")] int first);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_add_page_at([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_data")] QPdfData* newpage_qpdf, [NativeTypeName("qpdf_oh")] uint newpage, [NativeTypeName("QPDF_BOOL")] int before, [NativeTypeName("qpdf_oh")] uint refpage);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("QPDF_ERROR_CODE")]
    public static extern int qpdf_remove_page([NativeTypeName("qpdf_data")] QPdfData* qpdf, [NativeTypeName("qpdf_oh")] uint page);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdflogger_handle")]
    public static extern QPdfLoggerHandle* qpdflogger_default_logger();

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdflogger_handle")]
    public static extern QPdfLoggerHandle* qpdflogger_create();

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdflogger_cleanup([NativeTypeName("qpdflogger_handle *")] QPdfLoggerHandle** l);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdflogger_set_info([NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l, [NativeTypeName("enum qpdf_log_dest_e")] QPdfLogDestination dest, [NativeTypeName("qpdf_log_fn_t")] QPdfLogFunction fn, void* udata);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdflogger_set_warn([NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l, [NativeTypeName("enum qpdf_log_dest_e")] QPdfLogDestination dest, [NativeTypeName("qpdf_log_fn_t")] QPdfLogFunction fn, void* udata);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdflogger_set_error([NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l, [NativeTypeName("enum qpdf_log_dest_e")] QPdfLogDestination dest, [NativeTypeName("qpdf_log_fn_t")] QPdfLogFunction fn, void* udata);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdflogger_set_save([NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l, [NativeTypeName("enum qpdf_log_dest_e")] QPdfLogDestination dest, [NativeTypeName("qpdf_log_fn_t")] QPdfLogFunction fn, void* udata, int only_if_not_set);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdflogger_save_to_standard_output([NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l, int only_if_not_set);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdflogger_equal([NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l1, [NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* l2);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_run_from_argv([NativeTypeName("const char *const[]")] sbyte** argv);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_run_from_wide_argv([NativeTypeName("const wchar_t *const[]")] uint** argv);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_run_from_json([NativeTypeName("const char *")] sbyte* json);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdfjob_handle")]
    public static extern QPdfJobHandle* qpdfjob_init();

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdfjob_cleanup([NativeTypeName("qpdfjob_handle *")] QPdfJobHandle** j);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdfjob_set_logger([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j, [NativeTypeName("qpdflogger_handle")] QPdfLoggerHandle* logger);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdflogger_handle")]
    public static extern QPdfLoggerHandle* qpdfjob_get_logger([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_initialize_from_argv([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j, [NativeTypeName("const char *const[]")] sbyte** argv);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_initialize_from_wide_argv([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j, [NativeTypeName("const wchar_t *const[]")] uint** argv);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_initialize_from_json([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j, [NativeTypeName("const char *")] sbyte* json);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_run([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("qpdf_data")]
    public static extern QPdfData* qpdfjob_create_qpdf([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int qpdfjob_write_qpdf([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j, [NativeTypeName("qpdf_data")] QPdfData* qpdf);

    [DllImport("qpdf29", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void qpdfjob_register_progress_reporter([NativeTypeName("qpdfjob_handle")] QPdfJobHandle* j, [NativeTypeName("void (*)(int, void *)")] IntPtr report_progress, void* data);
}
