# Map Tile Implementation Tool
Tools to download OpenStreetMaps tiles for use in a Flutter Map Application


### How to use

1. Create the Tiles folder at the root of the C drive (or any folder you wish to store the downloaded tiles)
2. Download the Tile Implementation Tools from “link to github”
3. Open the “Tile Downloader” shortcut in the Tile Implementation Tools folder.
4. Download tiles from the page (enable downloading of multiple files to quicken process)

    4a. Input the bounds of the map you wish to download. This can be found by clicking the "Use OSM Service" link provided on the page. Save the bounds somewhere for multiple uses.

    4b. Input zoom level you wish to use (only download one zoom level at a time).

    4c. Choose Map Theme (optional (the theme used for the banff map is Carto - Light)).

    4d. Press the Download Tiles button at the bottom of the page.

    4e. Move the downloaded tiles to the Tiles folder you created in Step 1.

    4f. Open the FileRenamer program included in the Tile Implementation Tools folder. Make sure that all tiles are in your Tiles folder and they are all the part of the same zoom level and city.

    4g. Go through the FileRenamer program.

5. Repeat step four for each zoom level you need the tiles in (if you used a theme, make sure to keep that theme consistent among zoom levels).
6. Open the FolderRenamer program once again and print the pubspec information.
7. Copy the output of the pubspec print and paste it somewhere for future use.
8. Open the Commonwealth Walkway app in VS Code.
9. Navigate to the assets folder and open it in file explorer
10. Create a city folder with your city’s name inside the assets folder of the app if you have not already done so.
11. Create the “map” folder inside the city folder.
12. Copy the contents of the Tiles folder into the map folder.
13. Return to VS Code and open the pubspec.yaml file.
14. Paste the output of the FolderRenamer results under the the assets section, underneath the other assets references.
15. Reload VS Code before testing.

### Developer Links

For use with John Ryan's flutter_map package
https://github.com/johnpryan/flutter_map

OSM Tiles Downloader made by Gil Epshtain
https://github.com/Gil-Epshtain/OSM-Tiles-Downloader

