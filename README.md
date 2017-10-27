# ALM
## Semantic Versioning 2.0 for Netstandard 2.0 

Current status	: [![Build status](https://ci.appveyor.com/api/projects/status/97fbbqh8gv7wdmjh?svg=true)](https://ci.appveyor.com/project/Raph/alm)
[![codecov](https://codecov.io/gh/rducom/ALM/branch/master/graph/badge.svg)](https://codecov.io/gh/rducom/ALM)

Repository aimed to develop & improve a full CI pipeline, on NetStandard, with AppVeyor, Codecov, Sonarqube.

We publish artefact on different targets (internal appveyor nuget feed and official nuget.org server)



### Howto :

Use ComputeVersion.ps1 for automatic version numbering
```PowerShell
  - ps: . .\build\ComputeVersion.ps1
  - ps: $version = Compute "Alm\Alm.csproj" $env:APPVEYOR_BUILD_NUMBER $env:APPVEYOR_REPO_TAG $env:APPVEYOR_PULL_REQUEST_NUMBER
  - ps: Update-AppveyorBuild -Version $version.Semver
```

Then you can use the `$version` variable to access the computed next version :

- `$version.Nearest`	=  1.2.3.0		(last version found)
- `$version.Semver`	=  0.2.0-dev-0	(semver version)
- `$version.Assembly`	=  0.2.0.0		(assembly version)

Note on csproj : you should replace actual ```<Version>1.2.3.4</Version>``` with the following :

```Xml
	<VersionPrefix>1.2.3</VersionPrefix>
	<VersionSuffix>alpha4</VersionSuffix>
	<PackageVersion>1.2.3-alpha4</PackageVersion>
```

If you leave ```<Version>...</Version>``` in place, msbuild will not be able to substitute version with SemVer2 compatible versions.

### Version numbering :

|SemVer Version			|Use case								|Publish target	|Remark
|-------------------|-------------------------------------------|---------------|------
| 1.2.3-dev-Z		|local dev build 							| local			|Z = local counter
| 1.2.3-PR4824-X	|Pull Request build 						| private		|X = remote counter
| 1.2.3-rc3-X		|build on master, without commit tag		| private		|X = remote counter (last git tag = 1.2.3-rc3)
| 1.2.3-beta-X		|build on master, without commit tag 		| private		|X = remote counter (last git tag = 1.2.3)
| 1.2.3-rc3			|build on master, with git Tag = "1.2.3-rc3"| public		|pre-release
| 1.2.4				|build on master, with git Tag = "1.2.3" 	| public		|release

### Known issues :

- Currently, dotnet build CLI isn't supported by sonar, same for code coverage
- We currently need 2 compilations : 1 for sonar, 1 for the tests

### A word of caution :

If your package version contains one of the following, they will not be visible from the older clients (NuGet clients before 4.3.0 or Visual Studio before 2017 version 15.3):

- The pre-release label is dot-separated, e.g. 1.0.0-alpha.1
- The version has build-metadata, e.g. 1.0.0+githash

We recommend you consider this to be a beta-feature until a significant majority of our users are on these latest clients that understand Semantic Versioning 2.0.0. Read more on Semantic Versioning 2.0.0 NuGet support, [here](https://docs.microsoft.com/en-us/nuget/reference/package-versioning#semantic-versioning-200).



