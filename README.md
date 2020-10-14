# _Application Name_

#### _{Brief descrition on what application does}, {Date}_

#### By _Jeff Dinsmore & Grant Eadie_

## Description

_{Detailed description on what the application does.}_

## Setup/Installation Requirements

* _Clone this repository._
* _Open repository in your preferred code builder program. (This was built in VS Code)_
* _Check both of the .csproj files to ensure the proper framework under the "PropertyGroup" and "TargetFramework". I am using netcoreapp2.2. Your version may be newer_
* _If the framework does not match above, update the version of your netcoreapp by changing the numbers. For example if you are using netcoreapp 3.1, change netcoreapp2.2 to netcoreapp3.1_
* _In the terminal, cd into the NumberToWords.Tetst folder_
* _Type in the terminal "dotnet restore"_
* _Go to the appsettings.json file and check the password at the end of the code. It should look like this "pwd=epicodus". Change the password to your MySQL workbench password and save file

### Build the program into MySQL
* _Make sure that the terminal is in the root directory of the project. In this case it is ""
* _In the terminal, type in "dotnet ef migrations add Initial"
* _After migrations loads, type in the terminal "dotnet ef database update". Your MySQL database should now be up to date
* _To run the program, cd into the "" directory and type "dotnet run" in the terminal_
* _The program should now be running_

## Known Bugs

_No known bugs at the this time._

## Support and contact details

_Please check the .csproj files to ensure the proper framework you are running and change if necessary as described in the Setup section_

_Please check the appsettings.json file to ensure the proper password to your MySQL Workbench and update as necessary as described above_

_Any known issues, please reach out to Jeff Dinsmore by email at hello@jeffdinsmore.com._

## Technologies Used

* _C#_
* _CSHTML_
* _MySQL_
* _CSS_
* _Bootstrap_
* _VS Code_
* _LINQ_
* _Entity Framework Core_
* _EF Core Migrations_

## License

Copyright (c) 2020, **_Jeff Dinsmore & Grant Eadie_**

This software is licensed under the MIT license.