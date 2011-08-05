#include <Windows.h>
#include <Msi.h>
#include <MsiQuery.h>
#include <tchar.h>

#pragma comment(linker, "/EXPORT:ExtractPath=_ExtractPath@4")

static TCHAR buffer[4096]=_T("C:\\");

// "F:\Python27\python.exe" "%1" %*

__declspec(dllexport) UINT __stdcall ExtractPath (MSIHANDLE hInstall) {
  DWORD size=sizeof(buffer);
  HKEY key;

  // Turns out RegGetValue() is Vista only
  //if(ERROR_SUCCESS==RegGetValue(HKEY_CLASSES_ROOT, _T("Python.File\\shell\\open\\command"), NULL, RRF_RT_REG_SZ, NULL, buffer, &size))
  if(ERROR_SUCCESS==RegOpenKey(HKEY_CLASSES_ROOT, _T("Python.File\\shell\\open\\command"), &key))
  {
    if(ERROR_SUCCESS==RegQueryValueEx(key, _T(""), NULL, NULL, (LPBYTE) buffer, &size))
    {
      TCHAR *o=buffer, *i=buffer+1;
      while(*i!='"')
        *o++=*i++;
      while(*o!='\\')
        o--;
      *o=0;
    }
  }

  //MessageBox(NULL, buffer, _T("Message"), MB_OK);
  MsiSetProperty(hInstall, _T("PYTHONLOCATION"), buffer);
  return ERROR_SUCCESS;
}