#-------------------------------------------------------------------------------
# fim-attribute-values
#
# Create a C# file containing a class with constants for FIM attributes whose 
# validation string specifies a set of possible values, i.e. in the form
# "^(value1|value2|valueN)$"
#
# Date: 27/10/09
# Author: Paolo Tedesco - paolo.tedesco@cern.ch
#         https://espace.cern.ch/idm
#-------------------------------------------------------------------------------
param(
    $uri        = "http://localhost:5725",
    $credential = $null,                  
    $outfile    = "AttributeValues.cs",
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
    fim-attribute-values

SYNOPSIS
    Create a C# file containing a class with constants for FIM attributes whose 
    validation string specifies a set of possible values, i.e. in the form
    "^(value1|value2|valueN)$"
    
SYNTAX:
    fim-attribute-values [[-uri] <string>] [[-credential] <PSCredential>] [[-outfile] <string>] [[-namespace] <string>] [-help] [-debug]

PARAMETERS:
    -uri <string> 
        The base service address. The default value is 'http://localhost:5725'.
    
    -credential <PSCredential>
        The credentials to use to invoke the service, as returned by the Get-Credential cmdlet.
        By default, the current user's credentials are used.
    
    -outfile <string>
        The output file name. The default value is 'AttributeValues.cs'.
    
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

# get attribute type descriptions where StringRegex is present (specifying a 
# bogus value) and store them in an array 
$exportObjects = RunQuery "/AttributeTypeDescription[StringRegex!='xxx']"
$fimAttributes = @()
foreach ($exportObject in $exportObjects) {
    $fimTypeName = GetAttributeValue $exportObject Name
    # check if the attribute should be skipped
    if ("$fimTypeName" -match $AttributeSkipRegex) {
        Write-Debug "Skipping attribute $fimTypeName."
        continue
    }
    # check if validation regex indicates a list of values
    $stringRegex = GetAttributeValue $exportObject StringRegex
    $should_process = $stringRegex -match "\^\((?<Values>([^|]+\|?)+)\)(?<AllowEmpty>\??)\$"
    if ($should_process -eq $false){
        Write-Debug "Skipping ${fimTypeName}: validation string is not a list of values."
        continue
    }
    # does the match allow empty strings?
    $allowEmpty = $false
    if ($matches["AllowEmpty"]) {
        $allowEmpty = $true
    }
    # get the list of values
    $values = $matches["Values"]
    
    $fimAttribute = @{
        Name = $fimTypeName;
        CsName = GetCsName $fimTypeName;
        StringRegex = $stringRegex;
        AllowEmpty = $allowEmpty;
        Values = $values;
    }
    $fimAttributes = $fimAttributes + $fimAttribute

}

# sort attributes by name to make the cs file more readable
$fimAttributes = $fimAttributes | Sort-Object -Property @{Expression={$_.Name};Ascending=$true}

# write header
WriteFile @"
using System;

// Constants for FIM Attribute Values
// Automatically generated on $(Get-Date)
namespace $namespace {
"@

# write attribute names
foreach ($fimAttribute in $fimAttributes){
    # get the values (just split the match)
    $fimValues = $fimAttribute.Values.Split("|")
    
    # make valid C# identifiers for the values
    $clrValues = $(foreach ($fimValue in $fimValues) {GetCsName $fimValue})

    # write the enum
    WriteFile -append @"
    
    /// <summary>
    /// Values of the $($fimAttribute.Name) attribute.
    /// </summary>
    public static class $($fimAttribute.CsName)Values {
"@
    # write the set of values as constant strings
    if ($fimAttribute.AllowEmpty){
        WriteFile -append @"
        public const string Empty$($fimAttribute.CsName) = "";
"@
    }
    for ($i = 0;$i -lt $fimValues.length;$i++) {
        $fimValue = $fimValues[$i]
        $clrValue = $clrValues[$i]
        WriteFile -append @"
        public const string $clrValue = "$fimValue";
"@
    }
    
    # close the class
    WriteFile -append @"
    }
"@

}

# close the namespace
WriteFile -append @"

}
"@