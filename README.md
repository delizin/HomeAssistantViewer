# Home Assistant Viewer

This is a very simple Windows Form App that I created for my own personal use case. I've shared it here incase anyone else finds themselves in this same situation.

The Home Assistant Viewer is essentially a browser tab that is anchored to the top left corner of my secondary monitor. It is always in the background, so all other Winodws sit on top of it. It doesn't minimize, resize or show up on the taskbar. If my monitors go to sleep, it moves back to the secondary monitor when they wake up.
The goal is to keep my dashboard and controls always at hand and accessible with a clean borderless display. 

This program can be configured to use for any website if you desire. 

On first run, it creates a config.xml that exposes 3 variables:
```
  <url_string>http://homeassistant.local:8123/</url_string>
  <width_offset>0</width_offset>
  <height_offset>0</height_offset>
```

Set your desired URL in url_string.
Width and Height are positive integer offsets that let you reduce the size of the window in pixels. 
The Window is anchored to the top left corner so width decreases it on the right side and height decreases it on the bottom.

Personally, I use a width offset of 220 so I can fit my Steam friends window on the right hand side of my Home Assistant dashboard.

To use this software, download either the Zip or Rar archive in the Release folder, unextract or build it from source and then run the ```Home Assistant Desktop.exe``` file. I set mine to autostart on system boot so it is always available.

Note, I did get a false positive from Virus Total. I assume it is has something to do with using the web browser element in a form since that could be unsafe. However, I encourage you to review the source yourself and you will see there is nothing nefarious and you can compile it from source. 
https://www.virustotal.com/gui/file/6cefe049e6163f7b325e572aef35e01527ecb7b6fbb2b3c329809c5ce43653e5?nocache=1
