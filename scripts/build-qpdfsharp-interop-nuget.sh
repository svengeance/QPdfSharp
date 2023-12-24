#!/bin/bash

set -e

SCRIPT_DIR="$(dirname "$(readlink -f "$0")")"
VERSION=$1
VERSION_RX='^([0-9]+\.){2}(\*|[0-9]+)(-.*)?$' # 1.2.1 or 1.2.1-beta, thanks https://stackoverflow.com/a/35894180 :D
if [[ ! $VERSION =~ $VERSION_RX ]]; then
 echo "ERROR:<->Unable to validate package version: '$VERSION'"
 exit 1
fi

dotnet pack -p:PackageVersion="$VERSION" -o "${SCRIPT_DIR}/../artifacts" --include-symbols "${SCRIPT_DIR}/../src/QPdfSharp.Interop/QPdfSharp.Interop.csproj"