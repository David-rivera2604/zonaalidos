# Script de actualización de paquetes NuGet vulnerables y desactualizados
# Para ser ejecutado desde la raíz de la solución

Write-Host "=== Actualización de Paquetes NuGet Vulnerables ===" -ForegroundColor Green

# Función para actualizar un paquete en un proyecto específico
function Update-PackageInProject {
    param(
        [string]$ProjectPath,
        [string]$PackageName,
        [string]$NewVersion
    )
    
    Write-Host "Actualizando $PackageName a $NewVersion en $ProjectPath" -ForegroundColor Yellow
    
    try {
        # Actualizar usando NuGet CLI
        & nuget update "$ProjectPath" -Id "$PackageName" -Version "$NewVersion" -Reinstall
        Write-Host "✓ $PackageName actualizado correctamente" -ForegroundColor Green
    } catch {
        Write-Host "✗ Error actualizando $PackageName : $($_.Exception.Message)" -ForegroundColor Red
    }
}

# Función para verificar si un paquete existe en packages.config
function Test-PackageExists {
    param(
        [string]$PackagesConfigPath,
        [string]$PackageName
    )
    
    if (Test-Path $PackagesConfigPath) {
        $content = Get-Content $PackagesConfigPath
        return $content -match "id=`"$PackageName`""
    }
    return $false
}

Write-Host "`n=== FASE 1: Actualización de Oracle.ManagedDataAccess ===" -ForegroundColor Cyan

$oracleProjects = @(
    "Kernel\Architect.DataFactory\Architect.DataFactory.csproj",
    "webapp\aliados.csproj"
)

foreach ($project in $oracleProjects) {
    $packagesConfig = $project -replace "\.csproj$", "\packages.config"
    if (Test-PackageExists $packagesConfig "Oracle.ManagedDataAccess") {
        Update-PackageInProject $project "Oracle.ManagedDataAccess" "23.26.100"
    }
}

Write-Host "`n=== FASE 2: Actualización de Microsoft.AspNet.WebApi.* ===" -ForegroundColor Cyan

$webApiPackages = @(
    "Microsoft.AspNet.WebApi.Client",
    "Microsoft.AspNet.WebApi.Core", 
    "Microsoft.AspNet.WebApi.Cors",
    "Microsoft.AspNet.WebApi",
    "Microsoft.AspNet.WebApi.WebHost"
)

$webApiProjects = @(
    "Core\Architect.API.Core\Architect.API.Core.csproj",
    "Tron\Architect.API.Tron\Architect.API.Tron.csproj",
    "webapp\aliados.csproj"
)

foreach ($project in $webApiProjects) {
    foreach ($package in $webApiPackages) {
        $packagesConfig = $project -replace "\.csproj$", "\packages.config"
        if (Test-PackageExists $packagesConfig $package) {
            Update-PackageInProject $project $package "5.3.0"
        }
    }
}

Write-Host "`n=== FASE 3: Actualización de Microsoft.IdentityModel.* (Versión Compatible) ===" -ForegroundColor Cyan

# Usar versión 6.32.3 que es más compatible con .NET Framework 4.8
$identityPackages = @(
    "Microsoft.IdentityModel.Abstractions",
    "Microsoft.IdentityModel.Logging",
    "Microsoft.IdentityModel.Tokens",
    "Microsoft.IdentityModel.JsonWebTokens",
    "System.IdentityModel.Tokens.Jwt"
)

$identityProjects = @(
    "Core\Architect.API.Core\Architect.API.Core.csproj",
    "Core\Architect.API.Core.Business\Architect.API.Core.Business.csproj",
    "Core\Architect.API.Core.Utilities\Architect.API.Core.Security.csproj",
    "Monge\Aliados.Monge\Aliados.Monge.csproj",
    "Process\Architect.API.Process.WebApi\Architect.API.Process.WebApi.csproj",
    "webapp\aliados.csproj"
)

foreach ($project in $identityProjects) {
    foreach ($package in $identityPackages) {
        $packagesConfig = $project -replace "\.csproj$", "\packages.config"
        if (Test-PackageExists $packagesConfig $package) {
            Update-PackageInProject $project $package "6.32.3"
        }
    }
}

Write-Host "`n=== Verificación Final ===" -ForegroundColor Cyan

# Verificar que la solución compile
Write-Host "Compilando la solución para verificar compatibilidad..." -ForegroundColor Yellow
try {
    & dotnet build "aliados.sln" --configuration Release
    Write-Host "✓ Compilación exitosa" -ForegroundColor Green
} catch {
    Write-Host "✗ Error en compilación - revisar dependencias" -ForegroundColor Red
    Write-Host "Ejecutar: dotnet build aliados.sln --verbosity detailed" -ForegroundColor Yellow
}

Write-Host "`n=== Actualización Completada ===" -ForegroundColor Green
Write-Host "Revisar los siguientes puntos:" -ForegroundColor Yellow
Write-Host "1. Verificar que todos los proyectos compilen correctamente"
Write-Host "2. Ejecutar las pruebas unitarias si existen"
Write-Host "3. Verificar funcionalidad de autenticación JWT"
Write-Host "4. Revisar funcionalidad de conexión a Oracle"