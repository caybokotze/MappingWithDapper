
CREATE TABLE `users` (
  `id` int PRIMARY KEY,
  `name` string,
  `surname` string,
  `email` string,
  `address_id` int
);

CREATE TABLE `addresses` (
  `id` int PRIMARY KEY,
  `street_name` string,
  `number` int,
  `post_code` string,
  `city` string
);

ALTER TABLE `users` ADD FOREIGN KEY (`address_id`) REFERENCES `addresses` (`id`);
