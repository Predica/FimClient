#-------------------------------------------------------------------------------
# fim-attribute-names
#
# Create a C# file containing a class with constants for FIM attribute names.
#
# Date: 27/10/09
# Author: Paolo Tedesco - paolo.tedesco@cern.ch
#         https://espace.cern.ch/idm
#-------------------------------------------------------------------------------
param(
    $uri        = "http://localhost:5725",
    $credential = $null,                  
    $outfile    = "AttributeNames.cs",
    $namespace  = "IdentityManagement",
    [switch] $debug,
    [switch] $trace,
    [switch] $help)

#-------------------------------------------------------------------------------
# CONSTANTS
# skip attributes matching this expression
New-Variable -Option Constant AttributeSkipRegex "^SyncConfig-.*"
#-------------------------------------------------------------------------------

# quit on errors
$ErrorActionPreference="Stop"

# show help
if ($help) {
    @"
NAME
    fim-attribute-names

SYNOPSIS
    Creates a C# file containing a class that defines constant strings for FIM attribute names.
    Requires the FIMAutomation snapin to be installed.
    
SYNTAX:
    fim-attribute-names [[-uri] <string>] [[-credential] <PSCredential>] [[-outfile] <string>] [[-namespace] <string>] [-help] [-debug]

PARAMETERS:
    -uri <string> 
        The base service address. The default value is 'http://localhost:5725'.
    
    -credential <PSCredential>
        The credentials to use to invoke the service, as returned by the Get-Credential cmdlet.
        By default, the current user's credentials are used.
    
    -outfile <string>
        The output file name. The default value is 'AttributeNames.cs'.
    
    -namespace <string>
        The namespace of the generated class. The default value is 'IdentityManagement'.
    
    -debug <switch>
        Enable debug messages.

    -trace <switch>
        Trace script execution.

    -help <switch>
        Display this help message and exit.
        
"@
    exit
}

# source fim-utils
$scriptDir = Split-Path -Parent $myinvocation.mycommand.path
. "$scriptDir\fim-utils.ps1"

# get all the attribute type description objects and save them in an array as 
# hashtables
$exportObjects = RunQuery "/AttributeTypeDescription"
$fimAttributes = @()
foreach ($exportObject in $exportObjects) {
    $fimTypeName = GetAttributeValue $exportObject "Name"
    if ("$fimTypeName" -match $AttributeSkipRegex) {
        Write-Debug "Skipping attribute $fimTypeName."
        continue
    } else {
        Write-Debug "Adding attribute $fimTypeName."
    }    
    $fimAttribute = @{
        Name = $fimTypeName;
        CsName = GetCsName $fimTypeName;
        DisplayName = GetAttributeValue $exportObject DisplayName $fimTypeName;
        Description = GetAttributeValue $exportObject Description $fimTypeName;
    }
    $fimAttributes = $fimAttributes + $fimAttribute
}

# sort attributes by name to make the cs file more readable
$fimAttributes = $fimAttributes | Sort-Object -Property @{Expression={$_.Name};Ascending=$true}

# write the file
WriteFile @"
namespace $namespace {
    /// <summary>
    /// Names of FIM objects attributes.
    /// Automatically generated on $(get-date).
    /// </summary>
    public static class AttributeNames {
    
"@

# write attribute names
foreach ($fimAttribute in $fimAttributes){
    WriteFile -append @"
        /// <summary>
        /// $($fimAttribute.DisplayName)
        /// $($fimAttribute.Description)
        /// </summary>
        public const string $($fimAttribute.CsName) = "$($fimAttribute.Name)";
        
"@        
}

# write footer
WriteFile -append @"
    }
}
"@