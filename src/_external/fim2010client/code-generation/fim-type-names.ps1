#-------------------------------------------------------------------------------
# fim-type-names
#
# Create a C# file containing a class with constants for FIM type names.
#
# Date: 27/10/09
# Author: Paolo Tedesco - paolo.tedesco@cern.ch
#         https://espace.cern.ch/idm
#-------------------------------------------------------------------------------
param(
    $uri        = "http://localhost:5725",
    $credential = $null,                  
    $outfile    = "TypeNames.cs",
    $namespace  = "IdentityManagement",
    [switch] $debug,
    [switch] $trace,
    [switch] $help)

# quit on errors
$ErrorActionPreference="Stop"

# show help
if ($help) {
    @"
NAME
    fim-type-names

SYNOPSIS
    Creates a C# file containing a class that defines constant strings for FIM type names.
    Requires the FIMAutomation snapin to be installed.
    
SYNTAX:
    fim-type-names [[-uri] <string>] [[-credential] <PSCredential>] [[-outfile] <string>] [[-namespace] <string>] [-help] [-debug]

PARAMETERS:
    -uri <string> 
        The base service address. The default value is 'http://localhost:5725'.
    
    -credential <PSCredential>
        The credentials to use to invoke the service, as returned by the Get-Credential cmdlet.
        By default, the current user's credentials are used.
    
    -outfile <string>
        The output file name. The default value is 'TypeNames.cs'.
    
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
$exportObjects = RunQuery "ObjectTypeDescription"

$fimTypes = @()
foreach ($exportObject in $exportObjects) {
    $fimTypeName = GetAttributeValue $exportObject "Name"
    $fimType = @{
        Name = $fimTypeName;
        CsName = GetCsName $fimTypeName;
        DisplayName = GetAttributeValue $exportObject DisplayName $fimTypeName;
        Description = GetAttributeValue $exportObject Description $fimTypeName;
    }
    $fimTypes = $fimTypes + $fimType
}

# sort types by name to make the cs file more readable
$fimTypes = $fimTypes | Sort-Object -Property @{Expression={$_.Name};Ascending=$true}

# write header
WriteFile @"
namespace $namespace {
    /// <summary>
    /// Names of object classes.
    /// Automatically generated on $(get-date).
    /// </summary>
    public static class TypeNames {
    
"@

# write type names
foreach ($fimType in $fimTypes) {
    WriteFile -append @"
        /// <summary>
        /// $($fimType.DisplayName)
        /// $($fimType.Description)
        /// </summary>
        public const string $($fimType.CsName) = "$($fimType.Name)";
        
"@
}

# write footer
WriteFile -append @"
    }
}
"@