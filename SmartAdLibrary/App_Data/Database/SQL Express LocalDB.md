This project uses SQL Server Express LocalDB

It comes with two tools:
* SqlLocalDB Utility to manage SQL server instances
* sqlcmd utility to connect to DB instances

## SqlLocalDB
Manage SQL server instances through the `sqllocaldb` command.

```
$ SQL_LOCALDB_PATH="/c/Program File (x86)/Microsoft SQL Server/Client SDK/ODBC/130/Tools/Binn"
$ export PATH="${PATH}:${SQL_LOCALDB_PATH}"

$ sqllocaldb info
$ sqllocaldb create MSSQLLocalDB # Default automatic instance (add -s for autostart)
$ sqllocaldb info MSSQLLocalDB
$ sqllocaldb start MSSQLLocalDB
$ sqllocaldb stop MSSQLLocalDB   # Must stop before delete
$ sqllocaldb delete MSSQLLocalDB
```

## SqlCmd
Connect to SQL server instances through the `sqlcmd` command.

```
$ SQL_CMD_PATH="/c/Program File (x86)/Microsoft SQL Server/130/Tools/Binn"
$ export PATH="${PATH}:${SQL_CMD_PATH}"

$ sqlcmd -S "(LocalDB)\MSSQLLocalDB" # MYSQLLocalDB is instance name # -i $SQlFile to exec sql file
1> select name from master.sys.databases
2> go # Append go to execute all commands
```

Create database from *.mdf file

```
$ sqllocaldb i MSSQLLocalDB # Must be started
$ sqlcmd \
    -S "(LocalDB)\MSSQLLocalDB" \ 
    -Q "CREATE DATABASE Learndotnet ON ( \
            FILENAME='C:\smartdays\learndotnet\SmartAdLibrary\App_Data\Database\LearndotnetDB.mdf' \
        ) FOR ATTACH"
```

## Create and save a new database

With sqlcmd, otherwise Visual Studio can do it

```
1> create database learn ON (name="learn2", filename='C:\Users\jbardon\Documents\learn.mdf') log on (name="log2", filename='C:\Users\jbardon\Documents\log.ldf')
1> use learn
1> create table product (id int, name varchar(50))
1> insert into product (id, name) values (1, 'a')
```

## Checks on IIS

* Application pool > Advanced settings > Load user profile = TRUE
* C:\Windows\System32\inetsrv\config\applicationHost.config

```
<add name="learndotnet" autoStart="true">
    <processModel identityType="ApplicationPoolIdentity" loadUserProfile="true" setProfileEnvironment="true" />
</add>
```
* Restart application pool

This is because new LocalDB instance are run for new every users, even with same connection string.
Visual Studio and ApplicationPoolIdentity (IIS) access to different instances so different DB.

If make changes from sqlcmd then exit to save new state into .mdf file, let the connection to IIS and see changes through the IIS site. 

## Avoid checks with shared instances

ALL not work 

```
$ sqllocaldb c learndotnet -s
$ sqllocaldb share "DESKTOP-2M40LNJ\jbardon" learndotnet learndotnet
$ sqllocaldb stop learndotnet
$ sqllocaldb start learndotnet
$ sqlcmd -S "(LocalDB)\learndotnet" -Q "create database learndotnet on (filename='C:\smartdays\learndotnet\SmartAdLibrary\App_Data\Database\LearndotnetDB.mdf') for attach"
$ sqlcmd -S "(LocalDB)\learndotnet" -Q "exec sp_addsrvrolemember 'DESKTOP-2M40LNJ\jbardon', N'sysadmin'"

# [IIS APPPOOL/SITE NAME]
$ sqlcmd -S "(LocalDB)\learndotnet" -Q "create login [IIS APPPOOL\learndotnet.webapi.com] from windows; exec sp_addsrvrolemember 'IISAPPPOOL\learndotnet.webapi.com', N'sysadmin'"
$ sqlcmd -S "np:\[...]" -Q "create login test with password = 'test'; create user test"
```

https://codemegeek.com/2018/05/13/configure-iis-to-us-localdb/
https://forums.asp.net/t/2061083.aspx?Cannot+attach+the+file+mdf+as+database
 