function Show-Menu {
    param (
        [string[]]$Options
    )

    Write-Host "Choose an option:"
    for ($i = 0; $i -lt $Options.Count; $i++) {
        Write-Host "$($i + 1). $($Options[$i])"
    }

    $choice = Read-Host "Enter the number of your choice"

    if ($choice -ge 1 -and $choice -le $Options.Count) {
        return $Options[$choice - 1]
    } else {
        Write-Host "Invalid choice. Please enter a valid number."
        Show-Menu -Options $Options
    }
}

function Get-UserInput {
    param (
        [string]$Prompt
    )

    $userInput = Read-Host -Prompt $Prompt
    return $userInput
}

$option = Show-Menu -Options @("Migrate Identity", "Update", "Migrate Data")

if ($option -eq "Update") {  
    dotnet ef database update -s .\Socialite.Api\Socialite.Api.csproj -p .\Socialite.Infrastructure\Socialite.Infrastructure.csproj -c ApplicationIdentityDbContext
} else {
    $commands = @{
        'Migrate Identity' = {
            $customCommand = Get-UserInput -Prompt "Enter your migration name:"
            dotnet ef migrations add -s .\Socialite.Api\Socialite.Api.csproj -p .\Socialite.Infrastructure\Socialite.Infrastructure.csproj -c ApplicationIdentityDbContext $customCommand
        }
        'Migrate Data' = {
            $customCommand = Get-UserInput -Prompt "Enter your migration name:"
            dotnet ef migrations add -s .\Socialite.Api\Socialite.Api.csproj -p .\Socialite.Infrastructure\Socialite.Infrastructure.csproj -c ApplicationDbContext $customCommand
        }
    }

    if ($commands.ContainsKey($option)) {
        & $commands[$option]
    } else {
        Write-Host "Invalid option."
    }
}
