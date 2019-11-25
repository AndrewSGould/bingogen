insert into Boards
values
  ('SleepyCat', 'Test Board Creator')

insert into Cards
values
  (4.412, 'Test Card Generator UserOne', 1)

insert into Cards
values
  (3.213, 'Test Card Generator UserTwo', 1)

insert into Predictions
values
  ('Cat will sleep in bed', 4, 'https://testurl.com/catbed', 'Test Predictioner1', 1, 1)

insert into Predictions
values
  ('Cat will eat', 1, 'https://testurl.com/cateat', 'Test Predictioner1', 1, 1)

insert into Predictions
values
  ('Cat will play', 3, 'https://testurl.com/catplay', 'Test Predictioner2', 1, 2)

insert into Predictions
values
  ('Cat will sneak on counter', 2, 'https://testurl.com/catcounter', 'Test Predictioner2', 1, 2)

insert into Predictions
values
  ('Cat will eat plant', 3, 'https://testurl.com/catplant', 'Test Predictioner3', 1, null)


select *
from Boards

select *
from Cards

select *
from Predictions