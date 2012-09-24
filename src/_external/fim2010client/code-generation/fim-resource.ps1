#-------------------------------------------------------------------------------
# fim-resource
#
# Create a C# file containing a class that extends RmResource for a specific
# FIM resource type.
#
# Date: 06/11/09
# Author: Paolo Tedesco - paolo.tedesco@cern.ch
#         https://espace.cern.ch/idm
#-------------------------------------------------------------------------------
param(
    [string] $fimtype,
    [string[]] $ignore,
    [string] $uri = "http://localhost:5725",
    [System.Management.Automation.PSCredential] $credential,
    [string] $outfile,
    [string] $namespace = "Microsoft.ResourceManagement.ObjectModel.ResourceTypes",
    [string] $resourceClassTemplateFile = "resource-class",
    [switch] $systemOnly,
    [switch] $customOnly,
    [switch] $debug,
    [switch] $trace,
    [switch] $help)

# quit on errors
$ErrorActionPreference="Stop"

# show help
function ShowHelp() {
    @"
NAME
    fim-resource

SYNOPSIS
    Creates a C# file containing a class that defines constant strings for FIM type names.
    Requires the FIMAutomation snapin to be installed.
    
SYNTAX:
    fim-resource [fimtype] <string> [[ignore] <string[]>] 
        [[-uri] <string>] [[-credential] <PSCredential>] 
        [[-outfile] <string>] [[-namespace] <string>] [[-resourceClassTemplateFile] <string>]
        [-systemOnly] [-customOnly]
        [-help] [-trace] [-debug]

PARAMETERS:

    -fimtype <string>
        The name of the FIM resource type for which a strongly-typed C# class
        must be generated (Person, Group, Set...).
    
    -ignore <string[]>
        A list of attribute names to ignore. By default, the parameters defined
        in the base Resource class are ignored (Description, DisplayName, 
        ObjectID...).

    -uri <string> 
        The base service address. The default value is 'http://localhost:5725'.
    
    -credential <PSCredential>
        The credentials to use to invoke the service, as returned by the 
        Get-Credential cmdlet.
        By default, the current user's credentials are used.
    
    -outfile <string>
        The output file name. The default value is Rm<fimtype>.cs, e.g. 
        RmPerson.cs, RmGroup.cs, RmSet.cs
    
    -namespace <string>
        The namespace of the generated class. The default value is 
        'Microsoft.ResourceManagement.ObjectModel.ResourceTypes'.

    -resourceClassTemplateFile <string>
        The name of the resource class template file under the 
		fim-resource-templates folder.
        
    -systemOnly <switch>
		Read only system attributes (i.e. those not having a creator attribute set)
        
    -customOnly <switch>
		Read only custom attributes (i.e. those having a creator attribute set)
		
    -debug <switch>
        Enable debug messages.

    -trace <switch>
        Trace script execution.

    -help <switch>
        Display this help message and exit.
  
    -------------------------- EXAMPLE 1 --------------------------

    C:\PS>fim-resource Person AD_UserCannotChangePassword,Address,Assistant

    This command generates a wrapper for the Person FIM type, ignoring the 
    properties AD_UserCannotChangePassword, Address and Assistant. The output is 
    written to the RmPerson.cs file.
    
"@
}

if ($help) {
    ShowHelp
    exit
}

if (!$fimtype) {
    Write-Error "Specify the FIM resource name."
    exit
}

# source fim-utils
$scriptDir = Split-Path -Parent $myinvocation.mycommand.path
. "$scriptDir\fim-utils.ps1"

#-------------------------------------------------------------------------------
# GetTemplate
# Reads a file with given name from the "templates" folder and expands it.
# Returns null if the file does not exist.
#-------------------------------------------------------------------------------
function ExpandTemplate([string] ${templateFileName},[bool] ${exitIfMissing} = $false) {
    $templateFilePath = "${scriptDir}\fim-resource-templates\${templateFileName}.txt"
    if (Test-Path $templateFilePath) {
        $templateContents = [string]::Join([Environment]::NewLine,$(Get-Content $templateFilePath))
        $expandedTemplate = $ExecutionContext.InvokeCommand.ExpandString($templateContents)
        $expandedTemplate
    } elseif ($exitIfMissing) {
        Write-Error "Could not find required template file $templateFilePath"
        exit
    }
}

#-------------------------------------------------------------------------------
# Actual script execution
#-------------------------------------------------------------------------------

# list of attributes to ignore (defined in the base RmResource class)
$ignoreAttributeNames = "CreatedTime", "Creator", "DeletedTime", "Description", 
    "DetectedRulesList", "DisplayName", "ExpectedRulesList", "ExpirationTime", 
    "Locale", "MVObjectID", "ObjectID", "ObjectType", "ResourceTime"
if ($ignore -ne $null) {
    # additional attributes to ignore
    $ignoreAttributeNames = $ignoreAttributeNames + $ignore
}
    
# get CLR-compliant name
$clrTypeName = GetCsName "Rm${fimtype}"

# get file name
if ([string]::IsNullOrEmpty($outFile)) {
    $outFile = "${clrTypeName}`.cs"
}

Write-Host "Creating file ${outFile}"

# get all the attributes that are bound to the resource
if ($systemOnly) {
	# get only the bindings that do not have a creator (standard).
	$exportObjects = RunQuery "/BindingDescription[BoundObjectType=/ObjectTypeDescription[Name='${fimtype}'] and not (Creator!='00000000-0000-0000-0000-000000000000')]/BoundAttributeType"
} elseif ($customOnly) {
	# get only the bindings that have a creator (non-standard). For the standard ones, the creator is unset.
	$exportObjects = RunQuery "/BindingDescription[BoundObjectType=/ObjectTypeDescription[Name='${fimtype}'] and Creator!='00000000-0000-0000-0000-000000000000']/BoundAttributeType"
} else {
	$exportObjects = RunQuery "/BindingDescription[BoundObjectType=/ObjectTypeDescription[Name='${fimtype}']]/BoundAttributeType"
}

$attributes = @()
foreach ($exportObject in $exportObjects) {
    $attributeName = GetAttributeValue $exportObject "Name"
    if ($ignoreAttributeNames -contains $attributeName) {
        Write-Debug "Skipping attribute $attributeName."
        continue
    } 
    $csName = GetCsName $attributeName
    $attribute = @{
        Name = $attributeName;
        CsName = $csName;
        DisplayName = GetAttributeValue $exportObject "DisplayName" $attributeName;
        Description = GetAttributeValue $exportObject "Description" $attributeName;
        DataType = GetAttributeValue $exportObject "DataType";
        Multivalued = [bool]::Parse($(GetAttributeValue $exportObject "Multivalued"));
        MemberName = "_" + ${csName}.ToLower()[0] + ${csName}.Substring(1);
    }
    $attributes = $attributes + $attribute
}

# variables for template
${promotedProperties} = @()
${ensureAllAttributesExist} = @()
${attributeNamesClass} = @()

# loop through the selected attributes and generate the output class
foreach ($attribute in $attributes) {
    
    if ($attribute.Multivalued) {
        $templateName = "$($attribute.DataType)-multi"
    } else {
        $templateName = "$($attribute.DataType)-single"
    }
    
    $promotedProperty = ExpandTemplate $templateName
    if ($promotedProperty -eq $null) {
        # a template for the attribute type was not found; log a warning and
        # continue
        Write-Warning "Skipping attribute $($attribute.Name); template $templateName not found"
        continue
    }

    # create contents for template file
	${promotedProperties} = ${promotedProperties} + $promotedProperty
    ${EnsureAllAttributesExist} = ${EnsureAllAttributesExist} + 
        "            EnsureAttributeExists(AttributeNames.$($attribute.CsName), $($attribute.Multivalued.ToString().ToLower()));"
    $rmAttributeName=@"
            /// <summary>
            /// $($attribute.DisplayName)
            /// $($attribute.Description)
            /// </summary>
            public static RmAttributeName $($attribute.CsName) = new RmAttributeName(@`"$($attribute.Name)`");
"@
    ${attributeNamesClass} = ${attributeNamesClass} + $rmAttributeName
} 
# join the attribute names contents, which are arrays, to make them strings with
# newlines
${promotedPropertiesContents} = [string]::Join([Environment]::NewLine,${promotedProperties})
${ensureAllAttributesExistContents} = [string]::Join([Environment]::NewLine,${ensureAllAttributesExist})
${attributeNamesClassContents} = [string]::Join([Environment]::NewLine,${attributeNamesClass})

# write file
WriteFile $(ExpandTemplate $resourceClassTemplateFile $true)

Write-Host "Class ${clrTypeName} successfully written to ${outFile}"
