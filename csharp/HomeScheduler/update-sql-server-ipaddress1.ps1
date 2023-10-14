$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Path
Write-Output "Directory of the script : $scriptDir"

$vEthernetWsl = Get-NetIPAddress -InterfaceAlias "vEthernet (WSL)" -AddressFamily IPv4
$vEtherentWslIpAddress = $vEthernetWsl.IPAddress

Write-Output "vEthernet (WSL) IP address : $vEtherentWslIpAddress"

Write-Output "SQL Server IP1 BEFORE"
Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQLServer\SuperSocketNetLib\Tcp\IP1"

Write-Output "Setting Enabled = 1"
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQLServer\SuperSocketNetLib\Tcp\IP1" -Name "Enabled" -Value 1
Write-Output "Setting Active = 1"
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQLServer\SuperSocketNetLib\Tcp\IP1" -Name "Active" -Value 1
Write-Output "Setting IpAddress = $vEtherentWslIpAddress"
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQLServer\SuperSocketNetLib\Tcp\IP1" -Name "IpAddress" -Value "$vEtherentWslIpAddress"

Write-Output "SQL Server IP1 AFTER"
Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQLServer\SuperSocketNetLib\Tcp\IP1"

#SQL Server 2019 STOP
net stop SQLWriter
net stop SQLBrowser
net stop SQLSERVERAGENT
net stop MSSQLSERVER

# SQL Server 2019 START
net start MSSQLSERVER
net start SQLSERVERAGENT
net start SQLBrowser
net start SQLWriter