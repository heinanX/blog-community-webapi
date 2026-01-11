# Record of my progress and thought pattern

1/10/26

# Task 1: Set up Entity FrameWork to create a "code-first" database 

Step 1. Create Initial files:
- Install dependency packages for EntityFramework tools and SqlServer
- Setup folder Structure (Data folder => Entities)
- Set up connection string iside appsettings.

Step 2. Setup Data Models (Entities) for: 
- Category
- Comment
- Post
- User

Step 3. Adding application's database context:
- Set up DbSets to map all data models to the database
- Write Seed data for some initial data to work with - 3 users, 1 post, 1 comment, 2 categories

Issues faced:

Issue #1 multiple cascading paths:
On build, it complains about multiple FKs on the Comment data model as it may cause cycles or multiple cascade paths.

Solution:
To resolve this, I disabled cascading deletes on the User relationship. Now Users with comments cannot be deleted,
you have to delete all the comments or set the UserId to null. Deleting a post still cascades to its comments and deletes all data.
Future solve would just be to add a [isDeleted] property to User to effectively do a soft delete.

Daily reminder: I hate Chat gtp. It's as crippling as it's helpful.

---

# Task 2: Adding Swagger Documentation

Step 1. Add Automatic documentation with UI for easy overlook

- Add Nuget Package Swashbuckle
- Setup Swagger
- Add SwaggerUI for easy do

---

# Task 3: Set up Controllers

Step 1. Setup controllers in Main

Step 2. Create folders and classes for each model
- **Controllers**  for Calls
- **Repos** for Logic

- Step 3. Test one route to check working status

Issue faced: Comments weren't naturally included inside the User response. Included that data in the object and got an 
"JsonException: A possible object cycle was detected." error caused by the bidirectional navigation properties in User and Comment.

Solution: Added DTOs to break the circular navigation between the two models thus allowing safe serialization.


# Task 4: Introducing DTO classes


1/11/26 Creating Repositories, Services for each entity

# Task 1: Set up folder structure and classes.
- ceate Repository Interfaces and Repos
- create Service Interfaces and Services
- Write basic CRUD methods in each interface
- Implement all interface methods inside their respective classes

# Task 2: Add new version of Database
- Add Required to some elements inside all models
- Add Restrictions to some string fields inside models.
- Add default values to some fields inside models.

**Future note: Remove seed data in future updates.**

# Task 3: Work on Login method
- Write logic to check user against database
- Verify incoming credentials against stored user inside database
- test login endpoint
- Look up best practises for password hashing
- Read up on ASP.NET CORE Identity's built in password hashing
- Apply Identity's PasswordHasher into service layer

# Task 4: Troubleshooting PasswordHasher
- Successfully hashed the password
- Failed to make a successful verification
- Tried to look up documentation or articles but the information was scarce

Solution: With little to no documentation other than Microsoft's own,
I decided to go with a nuget packagage I'm already familiar with: BCrypt

# Task 5: Implementing BCrypt to hash passwords before they're saved to DB
- Successful login


--- Next up: Implement a JWT token upon successful login