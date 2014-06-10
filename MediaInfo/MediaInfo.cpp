// MediaInfo.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#pragma comment(lib, "mfplat.lib")
#pragma comment(lib, "Mfuuid.lib")
#pragma comment(lib, "mf.lib")

#define CHECK_HR(x) { HRESULT _hr = (x); if(FAILED(_hr)) return _hr; }

HRESULT DisplayInfo(LPCWSTR url);

int _tmain(int argc, _TCHAR* argv[]) {
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

HRESULT DisplayInfo(LPCWSTR url) {
	CComPtr<IMFSourceResolver> spResolver;
	CHECK_HR(::MFCreateSourceResolver(&spResolver));
	MF_OBJECT_TYPE type;
	CComPtr<IUnknown> spUnkSource;
	CHECK_HR(spResolver->CreateObjectFromURL(url, MF_RESOLUTION_MEDIASOURCE, NULL, &type, &spUnkSource));
	CComQIPtr<IMFMediaSource> spSource(spUnkSource);

	CComPtr<IMFPresentationDescriptor> spDesc;
	CHECK_HR(spSource->CreatePresentationDescriptor(&spDesc));

	UINT64 duration;
	spDesc->GetUINT64(MF_PD_DURATION, &duration);
	CTimeSpan span(duration / 10000000);
	wcout << "Duration: " << (LPCWSTR)span.Format(L"%H:%M:%S") << endl << endl;

	WCHAR buffer[128];
	DWORD count;
	spDesc->GetStreamDescriptorCount(&count);
	for(DWORD i = 0; i < count; i++) {
		BOOL selected;
		CComPtr<IMFStreamDescriptor> spStreamDesc;
		CHECK_HR(spDesc->GetStreamDescriptorByIndex(i, &selected, &spStreamDesc));
		if(selected) {
			// analyze stream descriptor
			CComPtr<IMFMediaTypeHandler> spHandler;
			spStreamDesc->GetMediaTypeHandler(&spHandler);
			CComPtr<IMFMediaType> spMediaType;
			spHandler->GetCurrentMediaType(&spMediaType);

			GUID major;
			spMediaType->GetMajorType(&major);
			bool video;
			if(major == MFMediaType_Audio)
				video = false;
			else if(major == MFMediaType_Video)
				video = true;
			else
				continue;

			// it's video or audio
			cout << "Stream Index: " << i << endl;
			cout << "Media type: " << (video ? "Video" : "Audio") << endl;

			UINT32 compressed;
			HRESULT hr = spMediaType->GetUINT32(MF_MT_COMPRESSED, &compressed);
			if(SUCCEEDED(hr))
				cout << "Compressed: " << (compressed ? "True" : "False");
			GUID guid;
			spMediaType->GetGUID(MF_MT_SUBTYPE, &guid);
			::StringFromGUID2(guid, buffer, 128);
			wcout << "Subtype GUID: " << buffer << endl;

			if(video) {
				UINT32 num;
				if(SUCCEEDED(spMediaType->GetUINT32(MF_MT_AVG_BITRATE, &num)))
					cout << "Average bitrate: " << (num >> 10) << " Kbps" << endl;
				UINT32 width, height;
				::MFGetAttributeSize(spMediaType, MF_MT_FRAME_SIZE, &width, &height);
				cout << "Frame size: " << width << " X " << height << endl;
				::MFGetAttributeRatio(spMediaType, MF_MT_FRAME_RATE, &width, &height);
				cout << "Frame rate: " << width / (float)height << " FPS" << endl;
			}
			else {
				UINT32 num;
				if(SUCCEEDED(spMediaType->GetUINT32(MF_MT_AUDIO_BITS_PER_SAMPLE, &num)))
					cout << "Bits/sample: " << num << endl;
				if(SUCCEEDED(spMediaType->GetUINT32(MF_MT_AUDIO_NUM_CHANNELS, &num)))
					cout << "# Channels: " << num << endl;
				if(SUCCEEDED(spMediaType->GetUINT32(MF_MT_AUDIO_AVG_BYTES_PER_SECOND, &num)))
					cout << "Average bytes/sec: " << num << endl;
				if(SUCCEEDED(spMediaType->GetUINT32(MF_MT_AUDIO_SAMPLES_PER_SECOND, &num)))
					cout << "Samples/sec: " << num << endl;
			}
			cout << endl;
		}
	}
	return S_OK;
}

