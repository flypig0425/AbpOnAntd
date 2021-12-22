. ".\common.ps1"

# $apiKey = $args[0]
# nuget setapikey ede6bb3f-f7c8-3d0b-accf-ae1604ccb26d -source https://nexus.united-imaging.com/repository/nuget-hosted/
$apiKey = "ede6bb3f-f7c8-3d0b-accf-ae1604ccb26d"

# Get the version
[xml]$commonPropsXml = Get-Content (Join-Path $rootFolder "../common.props")
$version = $commonPropsXml.Project.PropertyGroup.Version

# Publish all packages

# $files = Get-ChildItem *.nupkg -Name 
# foreach ($item in $files) {
#     & dotnet nuget push $item -s https://nexus.united-imaging.com/repository/nuget-hosted --api-key "$apiKey"
# }

foreach($project in $projects) {
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    & dotnet nuget push ($projectName + "." + $version + ".nupkg") -s https://nexus.united-imaging.com/repository/nuget-hosted --api-key "$apiKey"
}

# Go back to the pack folder
Set-Location $rootFolder
