#!/bin/bash

set -e

for name in jq unzip wget
do
  [[ $(which $name 2>/dev/null) ]] || { echo -en "\n$name needs to be installed.";deps=1; }
done
[[ $deps -ne 1 ]] && echo "OK" || { echo -en "\nInstall the above and rerun this script\n";exit 1; }

VERSION=$(curl --silent "https://api.github.com/repos/qpdf/qpdf/releases/latest" | jq -r .tag_name)
SCRIPT_DIR="$(dirname "$(readlink -f "$0")")"

LINUX_DOWNLOAD_URL="https://github.com/qpdf/qpdf/releases/download/${VERSION}/qpdf-${VERSION:1}-bin-linux-x86_64.zip"
WIN_DOWNLOAD_URL="https://github.com/qpdf/qpdf/releases/download/${VERSION}/qpdf-${VERSION:1}-mingw64.zip"

rm -rf "${SCRIPT_DIR}/tmp"
mkdir "${SCRIPT_DIR}/tmp" && cd "$_"
mkdir ./QPdf.RuntimeLibraries/runtimes/linux-x64/native -p
mkdir ./QPdf.RuntimeLibraries/runtimes/win-x64/native -p

wget --show-progress -qO qpdf_linux.zip "${LINUX_DOWNLOAD_URL}"
wget --show-progress -qO qpdf_win.zip "${WIN_DOWNLOAD_URL}"

unzip -qjo qpdf_linux.zip "**lib/*.so*" -d ./QPdf.RuntimeLibraries/runtimes/linux-x64/native
unzip -qjo qpdf_win.zip "**bin/*.dll" -d ./QPdf.RuntimeLibraries/runtimes/win-x64/native

cd ./QPdf.RuntimeLibraries

cat > ./QPdf.RuntimeLibraries.csproj <<EOL
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <LangVersion>latest</LangVersion>

    <IncludeBuildOutput>false</IncludeBuildOutput>
    <IncludeSymbols>false</IncludeSymbols>
    <SuppressDependenciesWhenPacking>true</SuppressDependenciesWhenPacking>

    <Authors>Jay Berkenbilt and Stephen (Sven) Vernyi</Authors>
    <Copyright>Jay Berkenbilt and Stephen (Sven) Vernyi</Copyright>
    <Description>Native package that wraps the QPdf binaries.</Description>
    <PackageProjectUrl>https://github.com/qpdf/qpdf</PackageProjectUrl>
    <PackageLicense>Apache License 2.0</PackageLicense>
    <!-- /qpdfsharp/scripts/tmp/package -->
    <PackageIcon>QPdf_128.png</PackageIcon>
    <PackageLicenseExpression>Apache-2.0</PackageLicenseExpression>
    <PackageReleaseNotes>Updates QPdf library to ${VERSION}</PackageReleaseNotes>
    <PackageTags>pdf qpdf qpdf.net qpdfsharp</PackageTags>
    <PackageVersion>${VERSION:1}</PackageVersion>
    <Product>QPdfSharp</Product>
    <RepositoryUrl>https://github.com/svengeance/QPdfSharp</RepositoryUrl>
    <RepositoryType>Git</RepositoryType>
    <Title>QPdfSharp.RuntimeLibraries</Title>
    <Version>${VERSION:1}</Version>
  </PropertyGroup>

  <ItemGroup>
    <Content Include="runtimes/**/*.so*" copyToOutput="true">
      <IncludeInPackage>true</IncludeInPackage>
      <CopyToOutput>true</CopyToOutput>
      <BuildAction>Content</BuildAction>
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    <PackagePath>/runtimes</PackagePath>
    </Content>
      <Content Include="runtimes/**/*.dll" copyToOutput="true">
        <IncludeInPackage>true</IncludeInPackage>
        <CopyToOutput>true</CopyToOutput>
        <BuildAction>Content</BuildAction>
        <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        <PackagePath>/runtimes</PackagePath>
      </Content>
  </ItemGroup>

  <ItemGroup>
    <None Include="../../../assets/QPdf_128.png">
      <Pack>True</Pack>
      <PackagePath>./</PackagePath>
      <Link>QPdfSharp_128.png</Link>
    </None>
  </ItemGroup>

</Project>
EOL

dotnet pack -o "${SCRIPT_DIR}/../artifacts/"
