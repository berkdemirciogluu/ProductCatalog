# ProductCatalog API
## Introduction
ProductCatalog API is a .NET Core Web API project that enables users to add their products and make them available to other users. This project is written using Postgresql with Hibernate, an ORM tool. In this project, PostgreSQL was the database and Hibernate was the ORM tool. The N-Tier Design Pattern was also taken into consideration when writing it. Moreover, validations and role based autorizations are handled with the power of AOP by using [Autofac](https://autofac.org/).
## How to Compile
This section will walk you through each step of the installation process required to use API. 
- [PostgreSQL 14](https://www.postgresql.org/download/) and [pgAdmin4](https://www.pgadmin.org/download/) must be installed on your computer. If you click on them, you will be directed to the relevant download pages.
- The database schema has to be created. In order to do that, [**DatabaseSchema.sql**](https://github.com/berkdemirciogluu/ProductCatalog/tree/master/PostgreSql.Database) file within the **PostgreSql.Database folder** must be downloaded.
- Open pgAdmin4 and create a new database. 
<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/pgadmin1.png" width="600"/>
</p>
<br>

- Name your database. Please make sure that **database name within pgAdmin4** and the **database name within the appsettings.json** file under the **ConnectionStrings** must be **the same** as given example below.
<br>

<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/2.png" width="700" />
</p>
<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/3.png" width="700"/>
</p>
<br>

- Right click on the created database (e.g. productcatalog) and click **Restore**

<br>
<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/4.png" width="400" />
</p>
<br>

- Select the file path that **DatabaseSchema.sql** is downloaded and click Restore.

<br>
<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/5.png" width="850" />
</p>
<br>

- Finally, open the **ProductCatalog.sln** file with Visual Studio Code 2022. Configure the appsettings.json file according to your requirements. **Do not forget to change ConnectionStrings path.**

# Features

- JSON Web Token (JWT) Authentication is implemented. **All endpoints are able to be used with authorization. Before using the API, please make sure you are logged in.**
- N-Tier Design Pattern principles is used.

<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/6.png" width="400" />
</p>


- All infrastructure for role based authorization are ready to use with **SecuredOperation()**. Database tables are also generated in the given script. In addition to role-based authentication, method-based authorization is also possible in the API as it can be seen the given figure below.
- Also validations are handled by taking advantage of Fluent Validaton within the scope of Aspect Oriented Programming. Bu using **ValidationAspect()** the code became more readable.
- For custom validations, a new class named BusinessRules is created. With its Run method, all custom validations are handled at the same time. 

<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/9.png" width="600" />
</p>

- For background jobs, RabbitMQ and Serilog are used.

## API Endpoints

|Endpoint  |Explanation|
|:----------|:----------|
|**Account/GetUserOffers** | Users can obtain their offers with the help of this endpoint.
|**Account/GetUserOffers** | Users can obtain received offers with the help of this endpoint.
|**Auth/Login** | Users can sign-in with the help of this endpoint.
|**Auth/Register** | Users can sign-up with the help of this endpoint.
|**Categories/GetAll** | Users can get all categories with the help of this endpoint.
|**Categories/Add** | Users can add a category with the help of this endpoint.
|**Categories/Update/{id}** | Users can update a category with the help of this endpoint.
|**Categories/Delete/{id}** | Users can delete a category with the help of this endpoint.
|**Offers/MakeAnOffer** | Users can make an offer to other products with the help of this endpoint.
|**Offers/Delete/{id}** | Users can delete an offer with the help of this endpoint.
|**Offers/Update/{id}** | Users can update an offer with the help of this endpoint.
|**Offers/ApproveOffer/{id}** | Users can approve an offer with the help of this endpoint.
|**Offers/DeclineOffer/{id}** | Users can decline an offer with the help of this endpoint.
|**Withdraw/DeclineOffer/{id}** | Users can withdraw an offer with the help of this endpoint.
|**Products/GetAll** | Users can get all products with the help of this endpoint.
|**Products/Add** | Users can add a product with the help of this endpoint.
|**Products/Update/{id}** | Users can update a product with the help of this endpoint.
|**Products/Delete/{id}** | Users can delete a product with the help of this endpoint.
|**Products/GetUserProducts/{id}** | Users can get their own products with the help of this endpoint.
|**Products/GetProductsById/{id}** | Users can get products associated with given category id with the help of this endpoint.

## Swagger
<p align="center">
<img src="https://github.com/berkdemirciogluu/ProductCatalog/blob/master/images/10.png" />
</p>

