## Project setup
> View -> SQL Server Object Explorer
1. Create a new Database called
2. Create a new Table called **Users**

	```sql
	CREATE TABLE [dbo].[Users]
	(
		[Id] INT NOT NULL PRIMARY KEY, 
		[Username] VARCHAR(50) NOT NULL, 
		[Password] VARCHAR(255) NOT NULL, 
		[Role] VARCHAR(50) NOT NULL
	)
	```
	
## Video tutorial
[Link to the video tutorial](https://www.youtube.com/watch?v=EyrKUSwi4uI)

### Create a Model related to a database table

1. Right click on Models -> Add -> New item ... -> ADO.NET Entity Data Model
	- Select **Generate from database**
	- New Connection ...
	- Fill the server name *(see it from the database properties)*
	- Select the database
	- Next, next
	- Select the Users table
	- Finish