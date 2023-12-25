#!/bin/bash

set -e

SCRIPT_DIR="$(dirname "$(readlink -f "$0")")"

dotnet pack -o "${SCRIPT_DIR}/../artifacts" --include-symbols "$@" "${SCRIPT_DIR}/../QPdfSharp.sln"
