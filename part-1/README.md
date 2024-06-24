# Part 1

## How to Run:

The scripts in the `setup` folder should be run in what turned out to be alphabetical order:

1. `create-db.sql`
2. `create-schema.sql`
3. `seed-data.sql`

After that, each task has its own folder with a script inside that can be run to get the result.

I put a comment at the top of most of the scripts that were not just a simple select.

I used basic `Id`s for my primary keys because I didn't realize until part 2 that you may have wanted Guids.

I also went ahead and created a stored procedure that did what you wanted to call in the latter part of the assessment, it is just a basic sp so that I could simulate and test it, it is created automatically with the rest of the schema.

This was generated for MS SQL Service 2022 Dev Edition. (I use SSMS 20 and Azure Data Studio to admin it because they each have features I like)
