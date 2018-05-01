#include "stdafx.h"
#include <cstdint>
#include <vcclr.h>

#pragma unmanaged
#include "../NativeInterop.NativeLib/NativeInterop.NativeLib.h"

static std::int32_t MultiplyDirect(std::int32_t a, std::int32_t b)
{
    return a * b;
}

static wchar_t GetFirstCharDirect(const wchar_t* str)
{
    return str ? *str : 0;
}

#include "NativeInterop.CppCli.h"
using namespace System;
using namespace System::Runtime::CompilerServices;

#pragma managed
namespace NativeInterop
{
    [MethodImplAttribute(MethodImplOptions::AggressiveInlining)]
    std::int32_t CppCli::Multiply(std::int32_t a, std::int32_t b)
    {
        return ::Multiply(a, b);
    }

    [MethodImplAttribute(MethodImplOptions::AggressiveInlining)]
    std::int32_t CppCli::MultiplyDirect(std::int32_t a, std::int32_t b)
    {
        return ::MultiplyDirect(a, b);
    }

    [MethodImplAttribute(MethodImplOptions::AggressiveInlining)]
    wchar_t CppCli::GetFirstChar(String^ str)
    {
        cli::pin_ptr<const wchar_t> ptr = PtrToStringChars(str);
        return ::GetFirstChar(ptr);
    }

    [MethodImplAttribute(MethodImplOptions::AggressiveInlining)]
    wchar_t CppCli::GetFirstCharDirect(String^ str)
    {
        cli::pin_ptr<const wchar_t> ptr = PtrToStringChars(str);
        return ::GetFirstCharDirect(ptr);
    }
}
