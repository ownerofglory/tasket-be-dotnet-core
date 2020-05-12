DROP TABLE IF EXISTS USER;

CREATE TABLE USER (
    id INT PRIMARY KEY AUTO_INCREMENT,
    firstname VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    username VARCHAR(64),
    role VARCHAR(20) NOT NULL,
    passwordhash BLOB NOT NULL,
    passwordsalt BLOB NOT NULL,
    token VARCHAR(512)
);