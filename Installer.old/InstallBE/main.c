#include <Windows.h>
#include <Msi.h>
#include <MsiQuery.h>
#include <tchar.h>

#pragma comment(linker, "/EXPORT:InstallBE=_InstallBE@4")

static TCHAR pythonlocation[4096]=_T(""), installdir[4096]=_T(""), workingdir[4096]=_T("");

__declspec(dllexport) UINT __stdcall InstallBE (MSIHANDLE hInstall) {
  DWORD len=sizeof(pythonlocation)/sizeof(TCHAR);
  int ret;
  HANDLE fh;
  TCHAR *semicolon;
  MsiGetProperty(hInstall, _T("CustomActionData"), pythonlocation, &len);
  semicolon=_tcschr(pythonlocation, ';');
  if(!semicolon) return ERROR_INVALID_PARAMETER;
  _tcscpy_s(installdir, sizeof(installdir)/sizeof(TCHAR), semicolon+1);
  *semicolon=0;

  if(0) {
  fh=CreateFile(_T("f:\\installbe.txt"), GENERIC_WRITE, FILE_SHARE_READ|FILE_SHARE_WRITE, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
  WriteFile(fh, pythonlocation, sizeof(TCHAR)*_tcslen(pythonlocation), &len, NULL);
  WriteFile(fh, _T("\r\n"), sizeof(TCHAR)*2, &len, NULL);
  WriteFile(fh, installdir, sizeof(TCHAR)*_tcslen(installdir), &len, NULL);
  WriteFile(fh, _T("\r\n"), sizeof(TCHAR)*2, &len, NULL);
  CloseHandle(fh);
  }

  _tcscat_s(pythonlocation, sizeof(pythonlocation)/sizeof(TCHAR)-_tcslen(pythonlocation), _T("\\python.exe"));
  _tcscpy_s(workingdir, sizeof(workingdir)/sizeof(TCHAR), installdir);
  _tcscat_s(workingdir, sizeof(workingdir)/sizeof(TCHAR)-_tcslen(workingdir), _T("\\BEforinstaller"));

  ret=(int) ShellExecute(NULL, NULL, pythonlocation, _T("setup.py install"), workingdir, SW_SHOWMINNOACTIVE);

  MsiSetProperty(hInstall, _T("InstallBESuccess"), (ret>32) ? _T("Success") : _T("Failure"));

  return (ret>32) ? ERROR_SUCCESS : (UINT) ret;
}