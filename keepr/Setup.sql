USE keepr1998;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),

--   PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorid VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255) NOT NULL,
--   views INT,
--   shares INT,
--   keeps INT,
-- -- Profile object?

-- PRIMARY KEY (id),

-- FOREIGN KEY (creatorId)
-- REFERENCES profiles(id)
-- ON DELETE CASCADE
-- );

-- CREATE TABLE vaults
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorid VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT NOT NULL Default 0,

-- PRIMARY KEY (id),

-- FOREIGN KEY (creatorId)
-- REFERENCES profiles(id)
-- ON DELETE CASCADE
-- );

-- CREATE TABLE vaultkeeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorid VARCHAR(255) NOT NULL,
--   vaultId INT NOT NULL,
--   keepId INT NOT NULL,

-- PRIMARY KEY (id),

-- FOREIGN KEY (creatorId)
-- REFERENCES profiles(id)
-- ON DELETE CASCADE,

-- FOREIGN KEY (vaultId)
-- REFERENCES vaults(id)
-- ON DELETE CASCADE,

-- FOREIGN KEY (keepId)
-- REFERENCES keeps(id)
-- ON DELETE CASCADE
-- );

/* Add To Collection */
/* INSERT INTO vaultkeeps (creatorId, vaultId, keepId) VALUES (8b7354e0-395d-455a-9305-eca2d5f0ba55, 5, 1);
INSERT INTO burgers (name, age, hungry) VALUES ("rover", 5, true);
INSERT INTO burgers (name, age, hungry) VALUES ("max", 6, true);
INSERT INTO burgers (name, age, hungry) VALUES ("rin-tin-tin", 25, true); */

--  INSERT INTO vaultkeeps (creatorId, vaultId, keepId) 
--  VALUES ("23df7361-bfa9-4183-8257-a0d4f0a0cdae", 4, 5);

      -- SELECT keep.*,
      -- v.id as VaultKeepId
      -- FROM vaultkeeps v
      -- JOIN keeps keep ON keep.id = v.keepId
      -- WHERE vaultId = 5;


-- NOTE this is all vaults since it's from account controller
      -- SELECT 
      --  vault.*,
      --  profile.* 
      --  FROM vaults vault 
      --  JOIN profiles profile ON vault.CreatorId = profile.id
      --  WHERE vault.CreatorId = '23df7361-bfa9-4183-8257-a0d4f0a0cdae';

      /* Find All of Collection */
-- SELECT * FROM vaultkeeps;
-- SELECT * FROM profiles;
-- SELECT * FROM vaults;
-- SELECT * FROM keeps;

      -- DELETE FROM keeps WHERE name='Test Name';
      -- DELETE FROM vaults WHERE name='Test Vault Name PUT';