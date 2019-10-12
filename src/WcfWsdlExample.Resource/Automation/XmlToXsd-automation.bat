ECHO OFF
echo Starting Convert to xml to XSD
::set xsdUtilPath="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\xsd.exe"
set xsdUtilPath="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\xsd.exe"
SET basePath=%~dp0
SET folderAndNameSpaceName=NorthwindDataSet
SET xmlFileName=northwind
SET dataProcessRoot=%basePath%..\..\WcfWsdlExample.DataLayer
SET currentXmlDataRelativeFolders=Resources\DataCache
SET xmlPath=%basePath%..\%currentXmlDataRelativeFolders%\%xmlFileName%.xml
SET dataSetRoot=%dataProcessRoot%\%folderAndNameSpaceName%\
SET xsdPath=%dataSetRoot%\%xmlFileName%.xsd
SET outputDir=%dataSetRoot%
SET namespace="WcfWsdlExample.DataLayer.%folderAndNameSpaceName%"
ECHO Tool Path %xsdUtilPath%
ECHO BasePath %dataProcessRoot%
ECHO DataSetRoot %dataSetRoot%
ECHO XML Path %xmlPath%
ECHO XSD Path %xsdPath%
ECHO OutputDir %outputDir%
:: %xsdUtilPath% -help
%xsdUtilPath% %xmlPath% /o:%outputDir%
%xsdUtilPath% /c %xsdPath% /o:%outputDir% /nologo /n:%namespace%