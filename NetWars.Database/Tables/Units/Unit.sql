create table [dbo].[Unit]
(
	[Id]                int             not null    identity (1, 1) primary key clustered,
	[Name]              varchar(100)    not null    default(''),
	[Description]       varchar(1000)   not null    default(''),
	[DeploymentType]    int             not null    default(0),
	[Movement]          int             not null    default(0),
	[MovementType]      int             not null    default(0),
	[Fuel]              int             not null    default(0),
	[Vision]            int             not null    default(1),
	[Price]             int             not null    default(1000),
	[PrimaryWeaponId]   int             not null    default(0)      foreign key references [dbo].[Weapon]([Id]),
	[SecondaryWeaponId] int             null                        foreign key references [dbo].[Weapon]([Id]),
	[CanReplenish]      bit             not null    default(0),
	[CanTransport]      bigint          not null    default(0),
	[CanRepair]         bit             not null    default(0),
	[CanHide]           bit             not null    default(0)
);