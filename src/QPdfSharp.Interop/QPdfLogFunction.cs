using System;
using System.Runtime.InteropServices;

namespace QPdf.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int QPdfLogFunction([NativeTypeName("const char *")] sbyte* data, [NativeTypeName("size_t")] UIntPtr len, void* udata);
