#include <Shlobj.h>
#include <Windows.h>

HRESULT GetKnownFolderName(int csidl, PWSTR* dispayName)
{
	PIDLIST_ABSOLUTE pidList;

	HRESULT hr = SHGetFolderLocation(0, csidl, 0, 0, &pidList);

	if (S_OK == hr)
	{
		IShellItem* item;

		hr = SHCreateItemFromIDList(pidList, IID_PPV_ARGS(&item));

		ILFree(pidList);

		if (S_OK == hr)
		{
			hr = item->GetDisplayName(SIGDN_NORMALDISPLAY, dispayName);
			item->Release();
		}
	}

	return hr;
}

extern "C"
__declspec(dllexport)
wchar_t* GetComputerFolderName()
{
	PWSTR szName = new wchar_t[20];

	CoInitialize(0);
	// CSIDL_DRIVES - "My Computer"
	GetKnownFolderName(CSIDL_DRIVES, &szName);
	CoUninitialize();

	return szName;
}