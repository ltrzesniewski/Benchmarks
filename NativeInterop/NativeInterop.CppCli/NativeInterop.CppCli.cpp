#include "stdafx.h"

#include "NativeInterop.CppCli.h"

using namespace System::Runtime::CompilerServices;

#pragma unmanaged
extern "C" __declspec(dllimport) std::int32_t __stdcall Multiply(std::int32_t a, std::int32_t b);

#pragma managed
namespace NativeInterop
{
    [MethodImplAttribute(MethodImplOptions::AggressiveInlining)]
    std::int32_t CppCli::Multiply(std::int32_t a, std::int32_t b)
    {
        return ::Multiply(a, b);
    }
}
