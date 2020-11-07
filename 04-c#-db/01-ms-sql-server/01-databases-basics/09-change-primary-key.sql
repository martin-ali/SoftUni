ALTER TABLE [Users]
DROP CONSTRAINT [PK_Minions_Users];

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Minions_Users] PRIMARY KEY(Id,Username)
-- ADD PRIMARY KEY(Id,Username)
