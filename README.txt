
******Database Integration*************

1. Open MySQL Workbench
2. Create Database ex: paybill_api or custom name
3. If the database name is something other than paybill_api, edit the script.aql file in the DBscript folder by replacing paybill_api with the database name, and then change the name in AppSettings.JSON file.
4. Run the script

5. If any changes in database
	1. Open Package Manager Console (Tools -> Nuget Package Manager -> Package Manager Console)
	2. Copy below  code and press enter key

		scaffold-dbcontext "Data Source=localhost;port=3306;Database=paybill_api;Uid=root;Pwd=password;" MySql.EntityFrameworkCore -outputdir DTOTemp -ContextDir Data -Context AppDBContext2 -dataannotations
	
	3. AppDBContext2.cs file will be created
	4. Copy all DBSet only and replace in AppDBContext.cs file
	5. Next, All data models will be created in DTOTemp folder
	6. Cut all data models from DTOTemp folder and replace in DTO folder
	7. And change namespace namespace PaybillAPI.DTOTemp to namespace PaybillAPI.DTO

