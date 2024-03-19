insert into [dbo].[Weapon] (Name, Description, MinimumRange, MaximumRange, Targets)
values ('Machine Gun', 'Standard issue infantry machine gun', 1, 1, 1)

insert into [dbo].[Unit] (Name, Description, DeploymentType, Movement, MovementType, Fuel, Vision, Price, PrimaryWeaponId, SecondaryWeaponId, CanReplenish, CanTransport, CanRepair, CanHide)
values ('Infantry', 'Standard foot soldier', 1, 3, 1, 99, 3, 1000, 1, null, 0, 0, 0, 0)