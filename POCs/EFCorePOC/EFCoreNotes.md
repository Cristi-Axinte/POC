
# This document contains important notes about EFCore

## EFCore general knowledge

#### What is EFCore?

    - EFCore is an Object-Relational Mapper for .NET. It allows developers to interact with a database using .NET objects and it also eliminates the need for most of the data-access code that typically needs to be written. ( EG: we don`t need to write SQL code )
    - EFCore Works with multiple database provider

# EFCore Approaches:

## Code-First

**What is it**

    We firstly create the entities and the database will be generated from these entities.
    The code is the master. EFCore takes care of creating or updating the database schema based on your code
    Database schemase cand be updated by using Migrations

**Advantages**
    
    - You don`t have to write SQL
    - Developers have full control over the code, making it easier to maintain and adjust as needed
    - Changes to the database schema can be managed through code, using code first migrations
    - Flexibility

**Disavatages**

    - Time-consuming: For complex databases, creating the model can take a long time
    - Some people are saying this: Requires migrations to manage schema changes ( not really that bad? imo )

## DataBase-First

**What is it**

    A database first approach involves using EFCores powerful tools to generate a .NET model that maps to your existing database schema.
    The database schema is the master. Any changes in the schema need to be updated in the model manually
    For schema changes in a Database-First setup, you would typically handle schema modifications directly in the database
 
**Advantages**
    
    - For complex databases, using database first can be quicker and more straightforward as the model is generated automatically.
    - A model can be generated quickly from an existing database, saving time in development

**Disavatages**

    - Developers have less control over the code that is generated
    - Since the database design is already set, there is less room for customization in the model classes

## Model-First

**What is it**

    The model is defined using a graphical or visual tool.
    After designing the model visually, both the code (entity classes) and the database schema are generated automatically based on the visual model
    Model-First is more design-centric, prioritizing a graphical overview of the database structure

## Types of loading

### Eager Loading
    - Eager loading refers to the technique where related entities are loaded alongside the primary entity in a single query.
    - It uses include/then include

### Lazy Loading
    - Lazy loading in Entity Framework Core means that related entities are not loaded when the main entity is initially queried. Instead, they are loaded only when you try to access a navigation property for the first time
    - This requires virtual navigation properties and lazy loading proxies enabled.
    - N+1 Query Problem: If you load a collection of entities and then access each entity's navigation property one-by-one, it can result in multiple queries being executed, which can degrade performance

   






