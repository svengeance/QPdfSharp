#!/bin/bash

IMAGE="qpdfsharp.interop.generator:local"
SCRIPT_DIR="$(dirname "$(readlink -f "$0")")"

docker build -f "${SCRIPT_DIR}/interop-generator.Dockerfile" -t ${IMAGE} ../
docker run -it --rm -v "${SCRIPT_DIR}/../src/QPdfSharp.Interop:/output" ${IMAGE}