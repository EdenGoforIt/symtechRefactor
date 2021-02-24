# Refactor the existing solution

# Changes made and reasons

- Implemented Service pattern 
  > Reson: Tightly coupled classes or objects are hard to maintain and cause issues at runtime. By implementing a service or repository pattern, you are able to unit test easily
  by creating an instance of the repository. The future TODO might be implementing unit tests for CRUD operations.
  
- HTTP status code
  > It was returning OK() in almost every method. It's better let the client knows the status of the request by HTTP STATUS such as created as 201, 404 NOT FOUND.

- Used Try Catch block
  > We need to efficiently catch the error especially when accessing the database. The better, it's better to know specific type of the exception so we can deal with in detail and better
  
- Added built in model state check when creating and updating
  > It's better to throw error before hand if the model stats is not valid
  
- Getting the list of accounts and transaction changed to fetch all together at once. 
  > For now, we are getting 10 or less accounts or transactions. But, thinking about fetching 10,000 records, then the current code should execute the same query 10,000 times which 
  cause a performance issues. So, I changed the query to get all lists and add to the list.
  

# Excuses

 -  due to time frame, I wasn't able to complete all refactoring the way I want. If I had more time, I might do...
   > Find the currec status code for create, update and delete failure and also after creating we should normally return 201, Delete 200 or 204.
   > I might create a more meaningful message instead of returning Exception messages.
   > I would like to follow the best practice of commit instead of commiting all files at one go
   

Sadly, I am not able to show front end portfolios here. But, I am more confident with JavaScript, its frameworks Angular and learning React, and other frontend languages such as CSS, AJAX. I have just created a new git hub to put my betters projects in for portfolio. 
   


