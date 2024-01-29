# ProductsApi with Basic Authentication

## Technologies & Tools

- Visual Studio 2022
- C#
- NUnit
  
## How to run & test the api?

- Build the code in Visual Studio and hit F5.
- The Swagger dashboard page will open in browser.
- Try out the healthcheck endpoint.
  - It should return 200 status code.
- Try out the products endpoing.
  - It shuold return 401 status code.
- The products endpoints require basic authentication
  - Click on the Authorize button at the top of the page to insert Authentication credentials.
  - Insert username & password. The allowable combinations are as below,
    - username1/password1 or admin/admin
    - Click the close button.
- Now try out the /api/products endpoint. It should return list of products.
- Also try out the /api/product/{colour} endpoint.
  - Try with either Red or Black colour. It should return a product by that colour.
  - Try with invalid colour. It should return 204 status code.
