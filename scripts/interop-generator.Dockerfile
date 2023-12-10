FROM mcr.microsoft.com/dotnet/sdk:8.0 as Base
WORKDIR /QPdfSharp

RUN apt update && apt install -y unzip clang
RUN dotnet tool install --global ClangSharpPInvokeGenerator --version 17.0.0

RUN wget https://www.nuget.org/api/v2/package/libclang.runtime.linux-x64/17.0.4 -O libclang.zip
RUN wget https://www.nuget.org/api/v2/package/libclangsharp.runtime.linux-x64/17.0.4 -O libclangsharp.zip

RUN unzip libclang.zip -d libclang
RUN unzip libclangsharp.zip -d libclangsharp

RUN mv libclang/runtimes/linux-x64/native/libclang.so ~/.dotnet/tools/.store/clangsharppinvokegenerator/17.0.0/clangsharppinvokegenerator/17.0.0/tools/net8.0/any/
RUN mv libclangsharp/runtimes/linux-x64/native/libClangSharp.so ~/.dotnet/tools/.store/clangsharppinvokegenerator/17.0.0/clangsharppinvokegenerator/17.0.0/tools/net8.0/any/

RUN git clone https://github.com/qpdf/qpdf.git && cd qpdf/include

RUN ls -la ~/.dotnet/tools

CMD ~/.dotnet/tools/ClangSharpPInvokeGenerator \
    --additional -m64  \
    --libraryPath qpdf29 \
    --remap \ 
        pdf_annotation_flag_e=PdfAnnotationFlag \
        pdf_form_field_flag_e=PdfFormFieldFlag \
        qpdf_encryption_status_e=QPdfEncryptionStatus \
        qpdf_error_code_e=QPdfErrorCode \
        qpdf_exit_code_e=QPdfExitCode \
        qpdf_json_stream_data_e=QPdfJsonStreamData \
        qpdf_object_stream_e=QPdfObjectStream \
        qpdf_object_type_e=QPdfObjectType \
        qpdf_r3_modify_e=QPdfR3Modify \
        qpdf_r3_print_e=QPdfR3Print \
        qpdf_stream_data_e=QPdfStreamData \
        qpdf_stream_decode_level_e=QPdfStreamDecodeLevel \
        qpdf_stream_encode_flags_e=QPdfStreamEncodeFlags \
        _qpdf_data=QPdfData \
        _qpdf_error=QPdfError \
        _qpdfjob_handle=QPdfJobHandle \
        _qpdflogger_handle=QPdfLoggerHandle \
        qpdf_log_dest_e=QPdfLogDestination \
        qpdf_log_fn_t=QPdfLogFunction \
        qpdf_write_fn_t=QPdfWriteFunction \
    --config generate-file-scoped-namespaces generate-setslastsystemerror-attribute multi-file compatible-codegen generate-helper-types \
    --include-directory /QPdfSharp/qpdf/include /usr/lib/llvm-14/lib/clang/14.0.6/include \
    --file-directory /QPdfSharp/qpdf/include/qpdf \
    --file Constants.h qpdf-c.h qpdflogger-c.h qpdfjob-c.h \
    --methodClassName QPdfInterop \
    --namespace QPdf.Interop \
    --output /output \
    --prefixStrip clang_