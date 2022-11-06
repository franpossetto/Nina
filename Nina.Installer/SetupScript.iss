#define MyAppName "Nina"
#define MyAppVersion "2.1.0"
#define MyAppExeName "Nina.exe"

[Setup]
AppId= 29EB0FF1-635A-4B8D-803D-1DB35438EF79
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
OutputBaseFilename= Nina
OutputDir=/output
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DefaultDirName={autopf}\Nina

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files] 
; General Files
Source: "..\Nina.Ribbon\PackageContents.xml"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle"; Flags: ignoreversion

; 2017 Files
Source: "..\Nina.R2017\bin\Release\Nina.R2017.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2017"; Flags: ignoreversion
Source: "..\Nina.R2017\Nina.R2017.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2017"; Flags: ignoreversion

; 2018 Files
Source: "..\Nina.R2018\bin\Release\Nina.R2018.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2018"; Flags: ignoreversion
Source: "..\Nina.R2018\Nina.R2018.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2018"; Flags: ignoreversion

; 2019 Files
Source: "..\Nina.R2019\bin\Release\Nina.R2019.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2019"; Flags: ignoreversion
Source: "..\Nina.R2019\Nina.R2019.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2019"; Flags: ignoreversion

; 2020 Files
Source: "..\Nina.R2020\bin\Release\Nina.R2020.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2020"; Flags: ignoreversion
Source: "..\Nina.R2020\Nina.R2020.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2020"; Flags: ignoreversion

; 2021 Files
Source: "..\Nina.R2021\bin\Release\Nina.R2021.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2021"; Flags: ignoreversion
Source: "..\Nina.R2021\Nina.R2021.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2021"; Flags: ignoreversion

; 2022 Files
Source: "..\Nina.R2022\bin\Release\Nina.R2022.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2022"; Flags: ignoreversion
Source: "..\Nina.R2022\Nina.R2022.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2022"; Flags: ignoreversion

; 2023 Files
Source: "..\Nina.R2023\bin\Release\Nina.R2023.dll"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2023"; Flags: ignoreversion
Source: "..\Nina.R2023\Nina.R2023.addin"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Contents\2023"; Flags: ignoreversion

; Langauges
Source: "..\Nina.Language\English_GB.json"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle"; Flags: ignoreversion
Source: "..\Nina.Language\English_USA.json"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle"; Flags: ignoreversion
Source: "..\Nina.Language\Russian.json"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle"; Flags: ignoreversion
Source: "..\Nina.Language\Spanish.json"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle"; Flags: ignoreversion

; Settings
Source: "..\Nina.Common\Settings\nina_settings.json"; DestDir: "C:\Nina"; Flags: ignoreversion


; Resources
Source: "..\Nina.Ribbon\Resources\nina_wall_switch_up_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_color_mode_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_hide_links_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_info_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_location_line_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_open_multiple_views_16.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_open_multiple_views_from_viewport_16.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_point_cloud_isolate_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_settings_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_show_hide_point_cloud_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_view_range_minor_16.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_view_range_plus_16.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_wall_by_dimension_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_wall_switch_down_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_wall_switch_up_30.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion
Source: "..\Nina.Ribbon\Resources\nina_actions_16.png"; DestDir: "{commonappdata}\Autodesk\ApplicationPlugins\Nina.bundle\Resources"; Flags: ignoreversion