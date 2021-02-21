# Nina for Revit
![.NET](https://img.shields.io/badge/.NET-4.7-green.svg)
![Revit API](https://img.shields.io/badge/RevitAPI-2018-blue.svg)
![Revit API](https://img.shields.io/badge/RevitAPI-2019-blue.svg)
![Revit API](https://img.shields.io/badge/RevitAPI-2020-blue.svg)
![Revit API](https://img.shields.io/badge/RevitAPI-2021-blue.svg)

Most of this work was done on Sunday mornings with [Nina](Nina.png).

## Installation
Run the file [Nina.msi](https://github.com/fpossetto/Nina/releases/latest/download/Nina.msi) provided in this repository.

## Overview

A collection of tiny tools to work faster in Revit.
Most of these commands are availables in Revit but as options in second windows. As they are actions that the users repeats very often, the goal is to be able to access them quickly, using keyboard shorcuts.

## Tools

### 1. Type up and Type down
Change selected types quickly. The order of the Types is the same you see in the Type Selector UI.

### 2. View Range (+) and View Range (-)
Modify the view range in the active view.

### 3. WallType Selector by dimension
This tool allows users to select WallTypes by drawing a dimension. The dimension will be compared with every WallType Width, by selecting the one that is most similar.

### 4. Show / Hide Point Clouds
Show or Hide point clouds in the current view.

### 5. Point Cloud Color Mode
This tool allow users modify the view range in the active view.

### 6. Show / Hide RVT Links
Show or Hide RVT links in the current view.

### 7. Show / Hide DWG Links
Show or Hide DWG links in the current view.

### 8. Open Multiple View(s)
Open one or multiple views doing the selection from the Project Browser.

### Recommentation
For correct use, use these commands as keyboard shorcuts. This is my personal configuration:

|Panel| Tool | Shortcut  | 
|-----|-----|-----|
|Type Selector|`Type-up`| `tt`|
|Type Selector|`Type-down`| `yy`|
|Type Selector|`View Range (+)`| `qq`|
|Type Selector|`View Range (-)`| `ww`|
|Type Selector|`WallType by Dimension`| `dd`|
|Point Clouds|`Show Hide Point Clouds`| `hp`|
|Point Clouds|`Color Mode: Set Normals`| `nn`|
|Links|`Show Hide RVT Links`| `hk`|
|Links|`Show Hide RVT Links`| `hc`|
|Views|`Open Multiple View(s)`| `om`|

*Before using Open Multiple View(s) as shorcut you have to click some empty space on the Ribbon bar.*

## Contributions
- Paloma Wilberger
- Federico Schmidt
