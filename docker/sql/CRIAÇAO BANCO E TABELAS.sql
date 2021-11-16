CREATE DATABASE RecipeExpress
GO

USE RecipeExpress
GO

CREATE TABLE CLIENT (
	client_id uniqueidentifier primary key,
	client_name varchar(50) not null,
	client_age int not null,
	client_genre varchar(1),
	createdAt datetime not null
)

CREATE TABLE BUY_LIST(
	list_id uniqueidentifier primary key,
	createdAt datetime not null
)

CREATE TABLE INGREDIENT(
	ingredient_id uniqueidentifier primary key,
	ingredient_name varchar(50) not null,
	type_id int not null,
	perishable bit not null,
	createdAt datetime not null
)

--ALTER TABLE INGREDIENT ADD type_id int NOT NULL;
--ALTER TABLE INGREDIENT ADD perishable bit NOT NULL;

CREATE TABLE INGREDIENT_TYPE(
	ingredient_type_id int primary key,
	type_description varchar(500) not null
)

drop table INGREDIENT_TYPE

CREATE TABLE RECIPE(
	recipe_id uniqueidentifier primary key,
	client_id uniqueidentifier,
	recipe_name varchar(50) not null,
	recipe_dificult int null,
	recipe_prepare_mode varchar(500) not null,
	createdAt datetime not null,
	createdBy varchar(50)
)

CREATE TABLE RECIPE_INGREDIENT(
	recipe_id uniqueidentifier  not null,
	ingredient_id uniqueidentifier not null,
	amountOf decimal,
	grams decimal
)

CREATE TABLE LIST_INGREDIENT(
	list_id uniqueidentifier  not null,
	ingredient_id uniqueidentifier not null,
	amountOf decimal,
	grams decimal
)


ALTER TABLE RECIPE_INGREDIENT
ADD CONSTRAINT FK_INGREDIENT_RECIPE_ID
FOREIGN KEY (recipe_id)
REFERENCES RECIPE(recipe_id)

ALTER TABLE RECIPE_INGREDIENT
ADD CONSTRAINT FK_RECIPE_INGREDIENT_ID
FOREIGN KEY (ingredient_id)
REFERENCES INGREDIENT(ingredient_id)

ALTER TABLE LIST_INGREDIENT
ADD CONSTRAINT FK_LIST_INGREDIENT_ID
FOREIGN KEY (ingredient_id)
REFERENCES INGREDIENT(ingredient_id)

ALTER TABLE LIST_INGREDIENT
ADD CONSTRAINT FK_INGREDIENT_LIST_ID
FOREIGN KEY (list_id)
REFERENCES BUY_LIST(list_id)

ALTER TABLE RECIPE
ADD CONSTRAINT FK_RECIPE_CLIENT_ID
FOREIGN KEY (client_id)
REFERENCES CLIENT(client_id)

ALTER TABLE INGREDIENT
ADD CONSTRAINT FK_INGREDIENT_TYPE_ID
FOREIGN KEY (type_id)
REFERENCES INGREDIENT_TYPE(ingredient_type_id)

select * from  INGREDIENT_TYPE







