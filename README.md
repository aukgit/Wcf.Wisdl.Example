# Project Name (Company Name)


# Project Structure

| Project Name | Readme  | Parent Project | Project Logic |
|--------------|---------|----------------|---------------|
|______________|_________|________________|_______________|

# Project Guide

# Project Video Demos

# Run Book

# Nuget Restore
There is another, newer and quicker way to do this from within Visual Studio. Basically, you do the following in Package Manager prompt:
`Install-Package NuGetPowerTools`
`Enable-PackageRestore`
- Nuget Restore:
   - Restores nuget on the solution `nuget update WcfWsdlExample.sln`
   - Restores nuget for specific project `Update-Package -reinstall -verbose -Project WcfWsdlExample.*`

 # Git Push Fix

 Reference : https://stackoverflow.com/questions/12651749/git-push-fails-rpc-failed-result-22-http-code-411
 ```
 git config http.postBuffer 524288000
 ```

# Nuget Known Issues

# Logs
- Application Logs will be available inside InstalledDirectory\Logs

# Review Guide
- http://bit.ly/2q8ajca

# Tools Use for this Project
- Visual Studio 2017 Enterprise.
- TortoiseGit
- Github Desktop
- GitExtensions
- GitBash
- InnoSetup
- Beyond Compare
- OpenVpn
- Resharper (Clean Code, Enhance ToolTip Plugin)

# IDE Settings
- https://drive.google.com/open?id=1IWH0rUsQrOFf3dMFM2u6rC7xhHPd9cIh