cd C:\$Cloned_Directory$\ProductsSalesReport\ProductsSalesReport

dotnet add package Microsoft.EntityFrameworkCore.InMemory --source https://api.nuget.org/v3/index.json

#make sure these are the same versions on the solution.
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.6" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.6" />

dotnet clean

dotnet build

cd C:\$Cloned_Directory$\ProductsSalesApp

Install Node.js (download and run install)

npm install -g @angular/cli@16

nvm install 18

nvm install use

npm install @angular-devkit/build-angular --save-dev

Run command : ng serve -o
