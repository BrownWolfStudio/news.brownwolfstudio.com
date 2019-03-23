  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetRoles` (
        `Id` varchar(767) NOT NULL,
        `Name` varchar(256) NULL,
        `NormalizedName` varchar(256) NULL,
        `ConcurrencyStamp` text NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetUsers` (
        `Id` varchar(767) NOT NULL,
        `UserName` varchar(256) NULL,
        `NormalizedUserName` varchar(256) NULL,
        `Email` varchar(256) NULL,
        `NormalizedEmail` varchar(256) NULL,
        `EmailConfirmed` bit NOT NULL,
        `PasswordHash` text NULL,
        `SecurityStamp` text NULL,
        `ConcurrencyStamp` text NULL,
        `PhoneNumber` text NULL,
        `PhoneNumberConfirmed` bit NOT NULL,
        `TwoFactorEnabled` bit NOT NULL,
        `LockoutEnd` timestamp NULL,
        `LockoutEnabled` bit NOT NULL,
        `AccessFailedCount` int NOT NULL,
        `GravatarEmailHash` text NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `Sources` (
        `Id` varchar(767) NOT NULL,
        `SourceId` text NULL,
        `Name` text NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetRoleClaims` (
        `Id` int NOT NULL,
        `RoleId` varchar(767) NOT NULL,
        `ClaimType` text NULL,
        `ClaimValue` text NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetUserClaims` (
        `Id` int NOT NULL,
        `UserId` varchar(767) NOT NULL,
        `ClaimType` text NULL,
        `ClaimValue` text NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetUserLogins` (
        `LoginProvider` varchar(767) NOT NULL,
        `ProviderKey` varchar(767) NOT NULL,
        `ProviderDisplayName` text NULL,
        `UserId` varchar(767) NOT NULL,
        PRIMARY KEY (`LoginProvider`, `ProviderKey`),
        CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetUserRoles` (
        `UserId` varchar(767) NOT NULL,
        `RoleId` varchar(767) NOT NULL,
        PRIMARY KEY (`UserId`, `RoleId`),
        CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `AspNetUserTokens` (
        `UserId` varchar(767) NOT NULL,
        `LoginProvider` varchar(767) NOT NULL,
        `Name` varchar(767) NOT NULL,
        `Value` text NULL,
        PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
        CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE TABLE `SavedArticles` (
        `Id` varchar(767) NOT NULL,
        `SourceId` varchar(767) NULL,
        `Author` text NULL,
        `Title` text NULL,
        `Description` text NULL,
        `Url` text NULL,
        `UrlToImage` text NULL,
        `PublishedAt` timestamp NULL,
        `Content` text NULL,
        `UserId` varchar(767) NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_SavedArticles_Sources_SourceId` FOREIGN KEY (`SourceId`) REFERENCES `Sources` (`Id`) ON DELETE RESTRICT,
        CONSTRAINT `FK_SavedArticles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `IX_SavedArticles_SourceId` ON `SavedArticles` (`SourceId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    CREATE INDEX `IX_SavedArticles_UserId` ON `SavedArticles` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20190227213339_InitialMigration')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20190227213339_InitialMigration', '2.2.3-servicing-35854');
END;

