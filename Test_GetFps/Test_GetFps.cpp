// Test_GetFps.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <mfidl.h>
#include <mfapi.h>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	if(argc != 2) {
      cout << "Usage: MediaInfo <path>" << endl;
      return 1;
   }
 
   ::CoInitializeEx(0, COINIT_MULTITHREADED);
   ::MFStartup(MF_VERSION);
 
   HRESULT hr = DisplayInfo(argv[1]);
   if(FAILED(hr)) {
      cout << "Error: " << hex << hr << endl;
   }
 
   ::MFShutdown();
   ::CoUninitialize();
 
   return 0;
}


inline HRESULT DisplayInfo(LPCWSTR url) {
   CComPtr<IMFSourceResolver> spResolver;
   CHECK_HR(::MFCreateSourceResolver(&spResolver));
   MF_OBJECT_TYPE type;
   CComPtr<IUnknown> spUnkSource;
   CHECK_HR(spResolver->CreateObjectFromURL(url, MF_RESOLUTION_MEDIASOURCE, NULL, &type, &spUnkSource));
   CComQIPtr<IMFMediaSource> spSource(spUnkSource);
}

// Helper function to get the frame rate from a video media type.
inline HRESULT GetFrameRate(
    IMFMediaType *pType, 
    UINT32 *pNumerator, 
    UINT32 *pDenominator
    )
{
    return MFGetAttributeRatio(
        pType, 
        MF_MT_FRAME_RATE, 
        pNumerator, 
        pDenominator
        );
}