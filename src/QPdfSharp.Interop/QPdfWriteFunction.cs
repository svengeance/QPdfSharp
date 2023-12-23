using System;
using System.Runtime.InteropServices;

namespace QPdfSharp.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate int QPdfWriteFunction([NativeTypeName("const char *")] sbyte* data, [NativeTypeName("size_t")] UIntPtr len, void* udata);
