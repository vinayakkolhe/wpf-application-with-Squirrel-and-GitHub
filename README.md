# wpf-application-with-Squirrel-and-GitHub

steps :- 


step 1 :- Install squirrel windows (specific version 1.9.0)
step 2 :- Install NuGet.CommandLine 

step 3 :- Open cmd in project directory and type "nuget spec". It will create nuget specification file which is .nuspec file.
step 4 :- Rename file ReleaseSpec.nuspec and Open .nuspec file Fillout data like ID, Version, Title, Author
	  Then add following thing at last with correct release path name like:-
          <files>
    		<file src="bin\Release\net5.0-windows\**" target="lib\net45"/>
  	 </files>

step 5 :- Open .csproj file and add following line :-


  <PropertyGroup>
    <NugetTools>$(PkgNuGet_CommandLine)\tools</NugetTools>
    <SquirrelTools>$(Pkgsquirrel_windows)\tools</SquirrelTools>

    <Version>1.0.1</Version>

    <NuspecFile>$(SolutionDir)WPFAppCore\ReleaseSpec.nuspec</NuspecFile>
  </PropertyGroup>

  <Target Name="GenerateRelease" AfterTargets="AfterBuild" Condition="$(Configuration) == Release">
    <XmlPeek XmlInputPath="$(NuspecFile)" Query="/package/metadata/id/text()">
      <Output TaskParameter="Result" ItemName="ID" />
    </XmlPeek>

    <Exec Command="$(NugetTools)\NuGet.exe pack $(NuspecFile) -Version $(Version) -Properties Configuration=Release -OutputDirectory $(SolutionDir)Deployment\GeneratedNugets" />

    <Exec Command="$(SquirrelTools)\Squirrel.exe --releasify $(SolutionDir)Deployment\GeneratedNugets\@(ID).$(Version).nupkg --releaseDir=$(SolutionDir)Deployment\Releases" />
  </Target>

step 6 :- Build with release mode.

