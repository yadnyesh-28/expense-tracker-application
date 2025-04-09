# 💸 Expense Tracking Application - .NET MVC

An intuitive and dynamic web application to track and manage daily income and expenses, built using ASP.NET MVC. 
This application allows users to monitor their financial activities through CRUD operations, data visualization, and an interactive dashboard.

---

## 🚀 Features

- ✅ Add, Edit, and Delete **Income** and **Expense** transactions
- 🗂️ Manage categories (e.g., Salary, Grocery, Festival, Commission, Maintenance)
- 📅 Filter and analyze financial data from the **last 7 or 15 days**
- 📊 Dynamic **Pie Chart** and **Doughnut Chart** using **Syncfusion**
- 📋 Tabular view of all transactions with inline actions
- 💰 Auto-calculated **Total Income, Total Expenses, and Remaining Balance**

---

## 🛠️ Technologies Used

- ASP.NET MVC (.NET Framework)
- C#
- Entity Framework
- Razor Views
- SQL Server (Local DB)
- Syncfusion Charts for data visualization
- Bootstrap & CSS for styling

---

## 📂 Project Structure
/Controllers - CategoryController.cs - TransactionController.cs /Models - Category.cs -
Transaction.cs /Views /Category - Index.cshtml - Create.cshtml /Transaction - Index.cshtml - Create.cshtml - Edit.cshtml /Shared -
_Layout.cshtml - _PartialView.cshtml wwwroot/ - CSS - JS

## 🖼️ Dashboard Overview

- Summary cards showing **Income**, **Expenses**, and **Balance**
- Interactive **Pie Chart** representing category-wise breakdown
- **Doughnut Chart** comparing total income and expenses
- Filters for time range (7 or 15 days)


1. Clone the repository:
   ```bash
   git clone https://github.com/yadnyesh-28/expense-tracker-application.git

 Let me know if you want to include a license, or if you're deploying it somewhere (like Azure or Vercel), I can add deployment instructions too!
 
🧑‍💻 How to Open the Project in Visual Studio
Follow these steps to open and run this project in Visual Studio:

1. Create a New Solution in Visual Studio  
   - Open Visual Studio  
   - Create a new Blank Solution  
   - Right-click on the solution > Add > Existing Project  
   - Navigate to the project folder and add the .csproj file

2. Restore and Update NuGet Packages  
   - Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution  
   - Click on Restore and Update any outdated packages  
   - If package issues persist, manually install the missing packages

3. Update the Connection String  
   - Open appsettings.json or Web.config  
   - Update the Connection String to match your local SQL Server setup

4. Build and Run the Solution  
   - Click on Build > Build Solution  
   - Once successful, click on Start (IIS Express) to run the application
