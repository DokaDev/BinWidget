#include "pch.h"
#include <Windows.h>
#include <shellapi.h>

/// <summary>
/// 
/// </summary>
/// <returns>IsRecycleBinEmpty :: bool</returns>
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

/// <summary>
/// 
/// </summary>
/// <param name="itemCount"></param>
/// <param name="totalSize"></param>
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

/// <summary>
/// StatusChanged Event
/// </summary>
typedef void(__stdcall* RecycleBinStatusChangedCallback)(bool isEmpty);
static RecycleBinStatusChangedCallback s_statusChangedCallback = nullptr;

extern "C" __declspec(dllexport) void SetStatusChangedCallback(RecycleBinStatusChangedCallback callback) {
	s_statusChangedCallback = callback;
}

// Trigger Event at Status of Recycle Bin changed
void NotifyRecycleBinStatusChanged(bool isEmpty) {
	if (s_statusChangedCallback) {
		s_statusChangedCallback(isEmpty);
	}
}

/// <summary>
/// Empty Recycle Bin
/// </summary>
/// <returns></returns>
extern "C" __declspec(dllexport) bool EmptyRecycleBin() {
	HRESULT hr = SHEmptyRecycleBinW(NULL, NULL, SHERB_NOCONFIRMATION | SHERB_NOPROGRESSUI | SHERB_NOSOUND);
	return SUCCEEDED(hr);
}