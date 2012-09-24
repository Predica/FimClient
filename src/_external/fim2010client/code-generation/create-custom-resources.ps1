#-------------------------------------------------------------------------------
# create-custom-resources
#
# Creates the '_custom.cs' files containing the partial classes with custom
# attributes definitions
#
# Date: 13/04/10
# Author: Paolo Tedesco - paolo.tedesco@cern.ch
#         https://espace.cern.ch/idm
#-------------------------------------------------------------------------------
param(
	$dir = $pwd,
    [string] $uri = "http://localhost:5725",
    [System.Management.Automation.PSCredential] $credential,
	$typeNames = @("Person")
)

foreach ($typeName in $typeNames) {
	Write-Host "Generating partial class with custom attributes for class ${typeName}."
	& .\fim-resource -uri $uri -credential $credential -debug -customOnly -resourceClassTemplateFile "resource-custom" $typeName -outfile "$dir\Rm${typeName}_custom.cs"
}