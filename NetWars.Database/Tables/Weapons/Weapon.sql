create table [dbo].[Weapon]
(
    [Id]            int             not null    identity(1, 1)  primary key clustered,
    [Name]          varchar(100)    not null    default(''),
    [Description]   varchar(1000)   not null    default(''),
    [MinimumRange]  int             not null    default(1),
    [MaximumRange]  int             not null    default(1),
    [Targets]       bigint          not null    default(0)
);