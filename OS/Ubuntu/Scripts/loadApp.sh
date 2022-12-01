#!/bin/bash

curl -L -o /tmp/cross_app.zip https://github.com/Alex-knu/Cross_platform/archive/refs/heads/master.zip
    
sudo mkdir -p /var/cross_app
sudo rm -rf /var/cross_app/src
sudo mkdir -p /var/cross_app/src
sudo chmod +x /var/cross_app/src
sudo unzip /tmp/cross_app.zip -d /var/cross_app/src
sudo rm -rf /var/cross_app/app
