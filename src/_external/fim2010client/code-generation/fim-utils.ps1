#-------------------------------------------------------------------------------
# fim-utils
#
# Utilities and common functions for FIM scripts.
#
# Date: 27/10/09
# Author: Paolo Tedesco - paolo.tedesco@cern.ch
#         https://espace.cern.ch/idm
#-------------------------------------------------------------------------------

# set debug variables (this could be done outside the script, but it's practical 
# to have a flag to quickly turn debug messages on)
if ($debug) {
    $DebugPreference = "Continue"
} else {
    $DebugPreference = "SilentlyContinue"
}
if ($trace) {
    Set-PSDebug -trace 2
} else {
    Set-PSDebug -trace 0
}

# LoadFimSnapin
# Ensure that the FIM snapin is loaded
#-------------------------------------------------------------------------------
function LoadFimSnapin() {
    # check if FIMAutomation snapin is loaded
    $snapin = $(Get-PSSnapin | Where-Object {$_.Name -eq "FIMAutomation"})
    if ($snapin -eq $null) {
        # not loaded; check if the snapin is registered and add it
        Write-Debug "Adding FIMAutomation snapin."
        $snapin = $(Get-PSSnapin -registered | Where-Object {$_.Name -eq "FIMAutomation"})
        if ($snapin -eq $null) {
            Write-Error "The FIMAutomation powershell snapin is not registered."
            exit
        }
        Add-PSSnapin FIMAutomation
    }
}

# ensure FIMAutomation snapin is loaded
LoadFimSnapin

# RunQuery
# Runs the query 
#-------------------------------------------------------------------------------
function RunQuery($query) {
    if ($credential -eq $null) {
        Write-Debug "Querying FIM with default credentials."
        Export-FIMConfig -Uri $uri -customConfig $query -OnlyBaseResources
    } else {
        Write-Debug "Querying FIM with credentials: $credential.UserName"
        Export-FIMConfig -Uri $uri -credential $credential -customConfig $query -OnlyBaseResources
    }
}

# GetAttributeValue
# gets the value of a single-valued attribute from an exported object
#-------------------------------------------------------------------------------
function GetAttributeValue($exportObject,[string] $name,$defaultValue = $null) {
    # get attribute with given name
    $attribute = $exportObject.ResourceManagementObject.ResourceManagementAttributes | 
        Where-Object {$_.AttributeName -eq $name}
    # get attribute value    
    if ($attribute -ne $null -and $attribute.Value) {
        $attribute.Value
    } else {
        $defaultValue
    }
}

# GetCsName
# gets a valid C# identifier starting from given name
#-------------------------------------------------------------------------------
function GetCsName($name) {
    $name -replace " ","" -replace "[^\w]","_"
}

# WriteFile
# writes to output file
#-------------------------------------------------------------------------------
function WriteFile($content,[switch]$append) {
    Out-File $outfile -encoding utf8 -append:$append -inputObject $content
}
