#pragma once

using namespace System;

namespace NativeInterop {
	public ref class CppCli abstract sealed
	{
	public:
		static std::int32_t __clrcall Multiply(std::int32_t a, std::int32_t b);
		static std::int32_t __clrcall MultiplyDirect(std::int32_t a, std::int32_t b);
	};
}
