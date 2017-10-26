
param(
    [string]$nuget_path= $("C:\nuget")
    )
    
    . .\build\ComputeVersion.ps1 
    
    $version = Compute .\Alm\Alm.csproj
    $props = "/p:Configuration=Debug,VersionPrefix="+($version.Prefix)+",VersionSuffix="+($version.Suffix)
    $propack = "/p:PackageVersion="+($version.Semver) 
    Write-Host $props
    Write-Host $propack
    dotnet restore
    dotnet build .\Alm.sln $props
    dotnet pack .\Alm\Alm.csproj --configuration Debug $propack -o $nuget_path
 
    
