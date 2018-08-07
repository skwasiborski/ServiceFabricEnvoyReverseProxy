#!/bin/bash

sed -i -e "s/Fabric_NodeName/$Fabric_NodeName/g" /etc/envoy/envoy.yaml
/usr/local/bin/envoy --service-cluster cluster0 --service-node _Node_0 -c /etc/envoy/envoy.yaml --max-obj-name-len 1024 -l trace