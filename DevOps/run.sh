#!/bin/bash
#Test 2
echo "I raned!"
$folder_name = $1
$new_folder_name = $2
mv $folder_name $new_folder_name
 
if [[ -d $new_folder_name ]];
then
	echo "Change folder name test, PASS"
else
	echo "Change folder name test, FAILD"
fi