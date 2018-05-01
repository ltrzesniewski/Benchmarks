#include "stdafx.h"

#define NATIVELIB_EXPORT
#include "NativeInterop.NativeLib.h"

std::int32_t __stdcall Multiply(std::int32_t a, std::int32_t b)
{
    return a * b;
}

wchar_t __stdcall GetFirstChar(const wchar_t* str)
{
    return str ? *str : 0;
}
