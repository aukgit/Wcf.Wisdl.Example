# WcfWsdlExample.Resource

- Copyable contents should be placed in here.
- Root of all project

## PreBuildEvent

```powershell
$(SolutionDir)src\WcfWsdlExample.Resource\Automation\XmlToXsd-automation.bat
```

Stopped Prebuild event due to XSD conversion issue with duplicate entityname: http://bit.ly/2VD4RJY | http://bit.ly/32bVCmp
For xml it is also same all the time. So no need to run on every build.
