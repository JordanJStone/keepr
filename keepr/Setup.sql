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

/* Find All of Collection */
-- SELECT * FROM profiles;