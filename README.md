# Few words about abstraction over static methods

## What is a static method?

It's a method that belongs to a class rather than to an object, can be called without instance of a class. 
> SettingsKeyInfoProvider.GetValue(key);  

## What is a static method really?

A static method is a sweet, convenient little lie. 

## What is abstraction?

Abstraction in OOP is the process of hiding internal implementation details of a class from the outside world. 

*World* -> Abstraction layer -> Concrete details  
e.g.  
Me wanting some data from the database -> Lovely ORM API -> Insides of the ORM optimizing scary SQL queries :O

Good level of abstraction makes us see better the borders of responsibilities, which leads to separation of concerns.

## What is separation of concerns?

Separation of concerns is a design principle, which tells us that we should design systems with the minimal
area of overlay between it's partitions. 

|  |  |
|--|--|--|
Displaying data to users | Connecting to external systems | Connecting to the database

## What are the benefits of doing it right? 

1. You are not overwhelmed with implementation details
2. You can easily find and fix bugs
3. Reusable components -> You save time and money
4. It's convenient 
5. You can finaly test stuff

Most importantly -> **You can think about logic, not about the implementation!**

## What is your enemy in getting there? 

1. Tight coupling 
2. Taking shortcuts
3. Technological debt
4. Lack of bigger picture
5. Lack of assertiveness
6. Not caring about the quality