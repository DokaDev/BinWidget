#pragma once
#include <Windows.h>

extern "C" __declspec(dllexport) bool IsRecycleBinEmpty();
extern "C" __declspec(dllexport) void GetRecycleBinStatus(long long* itemCount, long long* totalSize);