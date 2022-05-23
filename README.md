# TechnicalTest
This app is an API that returns tennis players stats for a given dataset.
The app has 3 EndPoints (for now) that can easily be used from swagger. You could use postman too but I recommand swagger as it contains documentation and is easier to use.

To develop this app, I used a code first approach using Entity Framework Core to make it easier to run the app and start using it features.
There is a DataSeed class that first reads the data from the data json file and seeds to the database if it is empty.
Simple, right?
But first, we need to run two commands to create our migration and our database.
To run this application you need to follow these steps:
_ Clone the repository on your local machine.
_ In PackageManagerConsole, write the following command:
   **Add-migration InitialCreate** (This will create the EF core migration named "InitialCreate" but you choose a name of your liking)
   **Update-Database** (To Create the database)

Congrats! The application is ready.

For the implementation, I tried to use a DDD architecture and the goal was to make the API extendable for other sports like football, ...
That is why I used "Sports" a global name, and Tennis as an aggregate.

As for the time working on the app, it took me one day and a half. I couldn't spend more time on it due to the responsabilities I have in my actual job.
Thank you for the oppotunity :)
