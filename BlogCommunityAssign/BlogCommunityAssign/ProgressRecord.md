# Record of my progress and thought pattern

1/10/26

Task: Set up Entity FrameWork to create a "code-first" database 

Step 1:
- Install dependency packages for EntityFramework tools and SqlServer
- Setup folder Structure (Data folder => Entities)
- Set up connection string iside appsettings.

Step 2 Setup Data Models (Entities) for: 
- Category
- Comment
- Post
- User

Step 3 Adding application's database context:
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