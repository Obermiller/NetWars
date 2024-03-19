--TODO - Users in Azure long term.
create table [dbo].[User] (
    [Id]        uniqueidentifier    not null    default(newSequentialId())  primary key clustered,
    [Email]     nvarchar(511)       not null    unique nonclustered,
    [Password]  nvarchar(255)       not null
);