CREATE TABLE "public"."Comments" ( 
  "Id" UUID NOT NULL,
  "MovieId" UUID NOT NULL,
  "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Name" TEXT NOT NULL,
  "Content" TEXT NOT NULL,
  CONSTRAINT "PK_Comments" PRIMARY KEY ("Id")
);
CREATE TABLE "public"."Genres" ( 
  "Id" INTEGER NOT NULL,
  "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Name" TEXT NOT NULL,
  CONSTRAINT "PK_Genres" PRIMARY KEY ("Id")
);
CREATE TABLE "public"."MovieGenres" ( 
  "GenreId" INTEGER NOT NULL,
  "MovieId" UUID NOT NULL,
  CONSTRAINT "PK_MovieGenres" PRIMARY KEY ("MovieId", "GenreId")
);
CREATE TABLE "public"."Movies" ( 
  "Id" UUID NOT NULL,
  "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Name" TEXT NOT NULL,
  "Description" TEXT NOT NULL,
  "ReleaseDate" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Rating" INTEGER NOT NULL,
  "TicketPrice" NUMERIC NOT NULL,
  "Country" TEXT NOT NULL,
  "Photo" TEXT NOT NULL,
  "Slug" TEXT NOT NULL,
  CONSTRAINT "PK_Movies" PRIMARY KEY ("Id")
);
CREATE TABLE "public"."Users" ( 
  "Id" INTEGER NOT NULL,
  "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Name" TEXT NOT NULL,
  "Username" TEXT NOT NULL,
  "PasswordHash" TEXT NULL,
  CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);
CREATE TABLE "public"."__EFMigrationsHistory" ( 
  "MigrationId" VARCHAR(150) NOT NULL,
  "ProductVersion" VARCHAR(32) NOT NULL,
  CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);
INSERT INTO "public"."Comments" ("Id", "MovieId", "CreatedAt", "Name", "Content") VALUES ('82f87631-619b-461d-a06e-0b71181768ed', '29890121-4158-4ecd-8d39-8f5c5d4220e5', '2023-02-05 16:34:21.903095+00', 'Daniel', 'What a nice movie');
INSERT INTO "public"."Comments" ("Id", "MovieId", "CreatedAt", "Name", "Content") VALUES ('033d61fd-3467-4650-8d6d-44f79d5c0142', '29890121-4158-4ecd-8d39-8f5c5d4220e5', '2023-02-05 16:35:16.479716+00', 'Daniel', 'You need to watch this movie');
INSERT INTO "public"."Genres" ("Id", "CreatedAt", "Name") VALUES (1, '2023-02-05 15:11:57.757751+00', 'Action');
INSERT INTO "public"."Genres" ("Id", "CreatedAt", "Name") VALUES (2, '2023-02-05 15:20:59.116057+00', 'Sci-Fi');
INSERT INTO "public"."Genres" ("Id", "CreatedAt", "Name") VALUES (3, '2023-02-05 15:23:58.088042+00', 'Adventure');
INSERT INTO "public"."MovieGenres" ("GenreId", "MovieId") VALUES (1, '3df857b7-19f7-4bb8-9811-c1c329bccdab');
INSERT INTO "public"."MovieGenres" ("GenreId", "MovieId") VALUES (2, '41605ef8-7a06-4b8f-b34b-5e9274ddff00');
INSERT INTO "public"."MovieGenres" ("GenreId", "MovieId") VALUES (1, '41605ef8-7a06-4b8f-b34b-5e9274ddff00');
INSERT INTO "public"."MovieGenres" ("GenreId", "MovieId") VALUES (3, '29890121-4158-4ecd-8d39-8f5c5d4220e5');
INSERT INTO "public"."MovieGenres" ("GenreId", "MovieId") VALUES (1, '29890121-4158-4ecd-8d39-8f5c5d4220e5');
INSERT INTO "public"."MovieGenres" ("GenreId", "MovieId") VALUES (2, '29890121-4158-4ecd-8d39-8f5c5d4220e5');
INSERT INTO "public"."Movies" ("Id", "CreatedAt", "Name", "Description", "ReleaseDate", "Rating", "TicketPrice", "Country", "Photo", "Slug") VALUES ('3df857b7-19f7-4bb8-9811-c1c329bccdab', '2023-02-05 15:11:56.451739+00', 'Justice League', 'Steppenwolf and his Parademons return after eons to capture Earth. However, Batman seeks the help of Wonder Woman to recruit and assemble Flash, Cyborg and Aquaman to fight the powerful new enemy.', '2017-04-03 00:00:00+00', 4, '3498', 'United States', 'b3kryjftwuj.jpg', 'justice-league');
INSERT INTO "public"."Movies" ("Id", "CreatedAt", "Name", "Description", "ReleaseDate", "Rating", "TicketPrice", "Country", "Photo", "Slug") VALUES ('41605ef8-7a06-4b8f-b34b-5e9274ddff00', '2023-02-05 15:20:57.963126+00', 'Spiderman - Far from home', 'Peter Parker, the beloved superhero Spider-Man, faces four destructive elemental monsters while on holiday in Europe. Soon, he receives help from Mysterio, a fellow hero with mysterious origins.', '2019-06-01 00:00:00+00', 4, '2998', 'United States', 'wqlrietl1qv.jpg', 'spiderman---far-from-home');
INSERT INTO "public"."Movies" ("Id", "CreatedAt", "Name", "Description", "ReleaseDate", "Rating", "TicketPrice", "Country", "Photo", "Slug") VALUES ('29890121-4158-4ecd-8d39-8f5c5d4220e5', '2023-02-05 15:23:56.823999+00', 'Avatar: The Way of Water', 'Jake Sully and Ney''tiri have formed a family and are doing everything to stay together. However, they must leave their home and explore the regions of Pandora. When an ancient threat resurfaces, Jake must fight a difficult war against the humans.', '2022-12-16 00:00:00+00', 2, '3200', 'United States', 'uxa0a4gb0zj.jpg', 'avatar-the-way-of-water');
INSERT INTO "public"."Users" ("Id", "CreatedAt", "Name", "Username", "PasswordHash") VALUES (1, '2023-02-05 16:10:25.320603+00', 'Daniel Nwachukwu', 'Daniel Nwachukwu', '8069F4CBAB11F4C2C3AA28DEF6992211126B913151891E808D701BCB209829C9:1AE5589E1CFFBB2BF623BA0C51766BDC:100000:SHA256');
INSERT INTO "public"."Users" ("Id", "CreatedAt", "Name", "Username", "PasswordHash") VALUES (2, '2023-02-05 16:14:19.022322+00', 'Daniel Nwachukwu', 'Daniel Nwachukwu', '5863ED40956DEAD75C23380C65F565109004A544507EE03E80ACECE638C5F2BD:4F5436C16B77811C9844A8BDDE784B9A:100000:SHA256');
INSERT INTO "public"."Users" ("Id", "CreatedAt", "Name", "Username", "PasswordHash") VALUES (3, '2023-02-05 16:17:24.982892+00', 'Daniel Nwachukwu', 'donsn', 'B2247523C93500980DFDF4921A510038EE4D8C6B342AE6A67100F1DED9079C6D:E3945CDEA316E3DA0BB1C7B27A559523:100000:SHA256');
INSERT INTO "public"."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20230205140400_DBRework', '7.0.2');
INSERT INTO "public"."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20230205150201_Optimizations', '7.0.2');
ALTER TABLE "public"."Comments" ADD CONSTRAINT "FK_Comments_Movies_MovieId" FOREIGN KEY ("MovieId") REFERENCES "public"."Movies" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."MovieGenres" ADD CONSTRAINT "FK_MovieGenres_Genres_GenreId" FOREIGN KEY ("GenreId") REFERENCES "public"."Genres" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."MovieGenres" ADD CONSTRAINT "FK_MovieGenres_Movies_MovieId" FOREIGN KEY ("MovieId") REFERENCES "public"."Movies" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
