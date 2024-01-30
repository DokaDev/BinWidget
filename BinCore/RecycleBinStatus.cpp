#include "pch.h"
#include <Windows.h>
#include <shellapi.h>

extern "C" __declspec(dllexport) bool IsRecycleBinEmpty() {
	SHQUERYRBINFO recycleBinInfo;
	recycleBinInfo.cbSize = sizeof(SHQUERYRBINFO);

	// Get Information of Recycle Bin
	HRESULT hr = SHQueryRecycleBinW(NULL, &recycleBinInfo);
	if (SUCCEEDED(hr)) {
		// Check the number of items in the Recycle Bin
		// If Empty : true / else : false
		return (recycleBinInfo.i64NumItems == 0);
	}

	// error :: return false
	return false;
}

extern "C" __declspec(dllexport) void GetRecycleBinStatus(long long* itemCount, long long* totalSize) {
	SHQUERYRBINFO recycleBinInfo;
	recycleBinInfo.cbSize = sizeof(SHQUERYRBINFO);

	HRESULT hr = SHQueryRecycleBinW(NULL, &recycleBinInfo);
	if (SUCCEEDED(hr)) {
		*itemCount = recycleBinInfo.i64NumItems;
		*totalSize = recycleBinInfo.i64Size / 1024;
	}
	else {
		*itemCount = 0;
		*totalSize = 0;
	}
}