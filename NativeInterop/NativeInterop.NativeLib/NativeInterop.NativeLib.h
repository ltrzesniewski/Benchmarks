#pragma once
#include <cstdint>

#ifdef NATIVELIB_EXPORT
    #define NATIVELIB_DLLFN extern "C" __declspec(dllexport)
#else
    #define NATIVELIB_DLLFN extern "C" __declspec(dllimport)
#endif

NATIVELIB_DLLFN std::int32_t __stdcall Multiply(std::int32_t a, std::int32_t b);
NATIVELIB_DLLFN wchar_t __stdcall GetFirstChar(const wchar_t* str);
