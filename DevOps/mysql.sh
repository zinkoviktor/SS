#!/bin/bash

#verify that user have a root access
if [[ "$(id -u)" != "0" ]]; then
   echo "This script must be run as root" 
   exit 1
fi

#verify first argument length
if [[ -z "$1" ]]; then   
   read -p "Enter username:" -t 20 username   
else
   username=$1
fi

#verify the name length
if [[ ${#username} -le 1 ]]; then
   echo "Username must be at least 2 characters" 
   exit 1
fi

#verify name duplicate

if [[ "$(mysql -se "SELECT EXISTS(SELECT 1 FROM mysql.user WHERE user = '$username')")" == 1 ]]; then
   echo "Wrond username, the same user in mysql!" 
   exit 1
fi

#verify second argument length
if [[ -z "$2" ]]; then    
   read -p "Enter password: " -s -t 20 password
else
   password=$2
fi

#create random password
if [ ${password} == "random" ]; then    
   password="$(openssl rand -base64 20)" 
fi

#verify password length
if [ ${#password} -le 9 ]; then   
   echo "Password must be at least 10 characters" 
   exit 1
else

#Create the new user
mysql <<MYSQL_SCRIPT
CREATE USER '$username'@'localhost' IDENTIFIED BY '$password';
GRANT ALL PRIVILEGES ON $username.* TO '$username'@'localhost';
FLUSH PRIVILEGES;
MYSQL_SCRIPT
fi

#TEST RESULT
if [[ "$(mysql -se "SELECT EXISTS(SELECT 1 FROM mysql.user WHERE user = '$username')")" == 1 ]]; then
   echo "$(tput setaf 2)TEST PASS$(tput sgr 0)"   
   echo "Name: ${username}"
   echo "Password ${password}" 	 
   exit 1
else
   echo "$(tput setaf 1)TEST FAILED$(tput sgr 0)"
   exit 1
fi
