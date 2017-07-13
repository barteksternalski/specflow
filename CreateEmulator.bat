@echo off
rem This script creates a new android emulator image

echo Removing old android image...
cmd /c %ANDROID_HOME%\tools\bin\avdmanager delete avd -n AppiumExample > nul

echo Creating new android image...
rem This will create a new android emulator based on Marshmallow (api23), adjust this numbers to match installed emulator image
echo no | cmd /c %ANDROID_HOME%\tools\bin\avdmanager -s create avd --force --name AppiumExample --abi google_apis/x86_64 --package "system-images;android-23;google_apis;x86_64" > nul

echo Starting emulator...
start /b %ANDROID_HOME%\tools\emulator -avd AppiumExample -gpu host -no-window -netfast -no-audio -no-boot-anim -no-snapshot-load -no-snapshot-save -camera-back none -camera-front none  > nul

echo Waiting for device..
%ANDROID_HOME%\platform-tools\adb wait-for-device shell "while [[ -z $(getprop sys.boot_completed) ]]; do sleep 1; done; input keyevent 82"
echo ...done.
echo Disabling animations...
%ANDROID_HOME%\platform-tools\adb shell "settings put global window_animation_scale 0.0"
%ANDROID_HOME%\platform-tools\adb shell "settings put global transition_animation_scale 0.0"
%ANDROID_HOME%\platform-tools\adb shell "settings put global animator_duration_scale 0.0"

echo Installing test app..
%ANDROID_HOME%\platform-tools\adb install selendroid-test-app-0.17.0.apk > nul

echo Killing emulator ...
%ANDROID_HOME%\platform-tools\adb emu kill > nul
echo ...done.