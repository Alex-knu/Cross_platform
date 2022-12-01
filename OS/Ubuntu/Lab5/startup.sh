#!/bin/bash

cd /var/cross_app/app
sudo kill -9 $(sudo lsof -t -i:5003)
sudo kill -9 $(sudo lsof -t -i:5004)
dotnet Web_cross_platform.dll --urls "http://*:5003;https://*:5004"
