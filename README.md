### PresentationFramework test build v 4.0.0.1

Severity	Code	Description	Project	File	Line
Error		Key file '35MSSharedLib1024.snk' is missing the private key needed for signing

HKEY_CURRENT_USER\SOFTWARE\Classes
HKCU\Software\Classes\Wow6432Node is correct: it's the redirected location that's accessed by 32-bit 

https://msdn.microsoft.com/en-gb/library/aa384253(v=VS.85).aspx  Registry Keys Affected by WOW64

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <runtime>
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
        <dependentAssembly>
          <assemblyIdentity name="PresentationFramework" publicKeyToken="31BF3856AD364E35" culture="neutral"/>
          <bindingRedirect oldVersion="0.0.0.0-4.0.0.1" newVersion="4.0.0.1"/>
        </dependentAssembly>
      </assemblyBinding>
  </runtime>
</configuration>

# .NET Reference Source

The referencesource repository contains sources from [Microsoft .NET Reference Source](http://referencesource.microsoft.com/)
that represent a subset of the .NET Framework.  This subset contains similar functionality to the class libraries that are being
developed in [.NET Core](https://github.com/dotnet/corefx).  We intend to consult the referencesource repository as we develop
.NET Core.  It is also for the community to leverage to enable more scenarios for .NET developers. 

Please note that the referencesource repository is read-only.  Questions and pull requests should be done through [.NET Core](https://github.com/dotnet/corefx).
