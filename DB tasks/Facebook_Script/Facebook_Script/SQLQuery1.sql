CREATE TABLE Users (
  id INT PRIMARY KEY,
  email VARCHAR(255) UNIQUE NOT NULL,
  password VARCHAR(255) NOT NULL,
  registration_date DATE NOT NULL
);

INSERT INTO Users (id, email, password, registration_date) VALUES
(1, 'user1@example.com', 'password1', '2023-10-01'),
(2, 'user2@example.com', 'password2', '2023-10-02'),
(3, 'user3@example.com', 'password3', '2023-10-03');

CREATE TABLE Friends (
  user_id1 INT NOT NULL,
  user_id2 INT NOT NULL,
  PRIMARY KEY (user_id1, user_id2),
  FOREIGN KEY (user_id1) REFERENCES Users (id),
  FOREIGN KEY (user_id2) REFERENCES Users (id)
);

INSERT INTO Friends (user_id1, user_id2) VALUES
(1, 2),
(1, 3),
(2, 3);

CREATE TABLE Walls (
  user_id INT NOT NULL,
  author_id INT NOT NULL,
  message TEXT NOT NULL,
  post_date DATE NOT NULL
);

INSERT INTO Walls (user_id, author_id, message, post_date) VALUES
(1, 2, 'Hello, user1!', '2023-10-01'),
(2, 1, 'Hi, user2!', '2023-10-02'),
(3, 2, 'Hey there, user3!', '2023-10-03');

CREATE TABLE Groups (
  group_id INT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  description TEXT
);

INSERT INTO Groups (group_id, name, description) VALUES
(1, 'Group1', 'This is Group1'),
(2, 'Group2', ''),
(3, 'Group3', 'Welcome to Group3');

CREATE TABLE GroupMembers (
  group_id INT NOT NULL,
  user_id INT NOT NULL,
  PRIMARY KEY (group_id, user_id),
  FOREIGN KEY (group_id) REFERENCES Groups (group_id),
  FOREIGN KEY (user_id) REFERENCES Users (id)
);

INSERT INTO GroupMembers (group_id, user_id) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 1),
(3, 2);
