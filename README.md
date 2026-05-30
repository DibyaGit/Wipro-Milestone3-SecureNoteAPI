# Secure Note-Taking API 🔐

A robust ASP.NET Core Web API for managing personal notes securely, featuring JWT authentication and BCrypt password hashing. Developed as part of the **Wipro NGA .Net Fullstack Angular** program (Milestone 3).

## Features
* **User Authentication:** Secure registration and login.
* **Password Security:** Passwords are mathematically hashed using BCrypt.
* **JWT Authorization:** Endpoints are protected via JSON Web Tokens with a 1-hour expiration.
* **CRUD Operations:** Create, Read, Update, and Delete personal notes securely.
* **Data Isolation:** Users can only view and modify their own securely authored notes.

## Tech Stack
* **Framework:** .NET 10.0 / ASP.NET Core Web API
* **Language:** C#
* **Database:** Entity Framework Core (In-Memory Database for testing)
* **Security:** BCrypt.Net-Next, JWT Bearer Authentication
* **Documentation:** Swagger / OpenAPI

## How to Run Locally
1. Clone this repository.
2. Open `SecureNoteAPI.sln` in Visual Studio.
3. Press `F5` or click the green **Play** button to build and start the application.
4. The API will launch, and you can test the endpoints via the built-in `.http` file or tools like Postman.

## API Endpoints
| Method | Endpoint | Description | Auth Required |
| :--- | :--- | :--- | :--- |
| `POST` | `/api/auth/register` | Register a new user | ❌ No |
| `POST` | `/api/auth/login` | Login and receive a JWT key | ❌ No |
| `POST` | `/api/notes` | Create a new note | 🔒 Yes |
| `GET` | `/api/notes` | Retrieve all notes for logged-in user | 🔒 Yes |
| `PUT` | `/api/notes/{id}` | Update an existing note | 🔒 Yes |
| `DELETE`| `/api/notes/{id}` | Delete a note | 🔒 Yes |

---
*Developed by Dibyajyoti Chakravarti*
