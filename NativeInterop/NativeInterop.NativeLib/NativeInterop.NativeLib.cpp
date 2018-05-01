#include "stdafx.h"

extern "C" __declspec(dllexport) std::int32_t __stdcall Multiply(std::int32_t a, std::int32_t b)
{
	return a * b;
}
