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
