# LifePrint Web Application
Project Overview
The LifePrint web application is a comprehensive tool designed to support self-mastery, well-being, personal growth, and peak performance solutions. Developed for Sheffield Hallam University, this application integrates a web data collection tool with a chatbot, facilitating the collection of user data for analysis and personalized feedback. It is integrated into an existing e-learning platform, providing a seamless user experience.

Key Features
Web Data Collection Tool: Engages users in data collection through interactive surveys and assessments.
Chatbot Implementation: An interactive chatbot for engaging users in conversation and data collection.
API Integration: Connects with the LifePrint e-learning platform to exchange data and extend functionality.
Database Management: A robust back-end for storing and managing user data efficiently.
Data Visualization: Offers users insights into their progress and results through intuitive visualizations.
Secure Authentication: Ensures user data is protected through a secure login mechanism.
Technologies Used
Frontend: Blazor, Razor Pages
Backend: ASP.NET Core, C#
Database: SQL Server
ORM: Entity Framework Core
Others: HTML, CSS, JavaScript (for enhancing UI interactions)
Installation & Setup
Prerequisites:

.NET 5.0 SDK or later
SQL Server
Visual Studio 2019 or later (recommended for development)
Clone the Repository:

bash
Copy code
git clone 
cd LifePrint
Database Setup:

Ensure SQL Server is running.
Update the connection string in appsettings.json to match your database credentials.
Run Migrations:

sql
Copy code
dotnet ef database update
Run the Application:

arduino
Copy code
dotnet run
Alternatively, open the project in Visual Studio and press F5 to run the application.

Usage
Home Page: Navigate to the main landing page to learn about the LifePrint platform.
Login/Register: Securely log in or register for an account to access personalized features.
Surveys: Participate in surveys and assessments through the chatbot interface.
Results: View personalized feedback and results based on survey responses.
Settings: Manage account settings and preferences.

Contributing
We welcome contributions to the LifePrint project. Please read our contributing guidelines before submitting pull requests.

License
This project is licensed under the MIT License.
