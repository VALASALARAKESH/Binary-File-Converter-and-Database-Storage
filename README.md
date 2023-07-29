# Binary File Converter and Database Storage

**Title:** .NET Forms for Converting Files to Binary and Storing in Database and Retrieving Data from Database.

**Description:**
This repository contains a set of .NET forms that allow users to convert any file to binary form and store the binary form to a database. The forms are also able to retrieve the data from the database. The forms are easy to use and can be used to convert any type of file, including images, documents, audio and video files.

# Features:
1. The forms allow users to select any file to convert to binary form.

2. The forms allow users to specify the name of the database and the table where the binary data will be stored.

3. The forms automatically convert the file to binary form and store the binary data in the database.

4. The forms also allow users to manually specify the content type, content ID, and category ID for the file.

5. The forms have a "Save" button that stores the content in the database, and a "Refresh" button that updates the database content in the form.

6. The forms also have an "Open" button that allows users to open the content stored in the database.

7. The forms use the following queries to store and retrieve data from the database:
   
   `INSERT INTO ContentData (FileName, DataFile, FilePath, Extension, FileSize, ContentType, ContentID, CategoryID) VALUES (@FileName, @DataFile, @FilePath, @Extension, @FileSize, @ContentType, @ContentID, @CategoryID)`

   `SELECT DataID, FileName, FilePath, Extension, FileSize, ContentType, ContentID, CategoryID FROM ContentData`

8. The forms are connected to a SQL Server database named "Content_Management_System". The connection string is:
   
   `SqlConnection(@"Data Source=MADDY;Database=Content_Management_System;Integrated Security=true;");`

   * You can connect your database to the Form using the connection string and replacing the "MADDY" and "Content_Management_System".
   * **Database Connection String:** Replace "Your_Database_Connection_String" in the connectionString variable with your actual database connection string. This string should point to the database where you want to store the binary data.

# Requirements:
* The forms require .NET Framework 4.5 or higher.

* The forms require a database that supports the ADO.NET Entity Framework.

* The forms require a SQL Server database named "Content_Management_System".

# Usage
1. Clone the repository to your local system. You can do this by using the following command in a command prompt:
   https://github.com/VALASALARAKESH/Binary-File-Converter-and-Database-Storage.git

2. Open the project with Visual Studio. You can do this by double-clicking on the `Binary File Converter and Database Storage.sln` file in the cloned repository.

3. Make sure that you have .NET Framework 4.5 or higher installed.

4. If you are using a different database server or if you do not have integrated security enabled, you will need to update the connection string in the `App.config` file.

5. Once you have updated the connection string, you can start using the forms.

6. Here are the steps on how to open the project with Visual Studio Windows Form App (.NET Framework):
   
   1. Open Visual Studio.
  
   2. Click on the "File" menu and select "Open".
  
   3. In the "Open" dialog, navigate to the cloned repository and select the `Binary File Converter and Database Storage.sln` file.
  
   4. Click on the "Open" button.
  
   5. The execution of the .NET Forms application involves running the compiled executable file (usually with a ".exe" extension) on a Windows machine. Here's a step-by-step guide on how to execute the form:
      
      **1. Build the Project:**
           If you have the complete source code of the `.NET` Forms application, you need to build the project first to generate the executable file. Open the project in Visual Studio (or any other IDE you are using) and build the solution. This will create the executable file in the `"bin"` or `"bin\Debug"` (depending on the build configuration) folder of your project.
     
      **2. Locate the Executable:**
           Once the project is successfully built, navigate to the folder containing the executable file. It should have the same name as your project or the form itself, followed by the `".exe"` extension.
      
      **3. Double-Click to Run:**
           Simply double-click on the executable file to run the application. Alternatively, you can run it from the command prompt by navigating to the folder containing the executable and typing the name of the file.
      
      **4. Application Execution:**
           After executing the application, the `.NET` Forms window will open, showing the user interface. The form should contain the Browse button to select the file, fields for displaying the file details (file name, path, extension, and size), and input fields for manual entry of content type, content ID, and category ID.

      **5. Converting and Storing Files:**
           Use the `Browse` button to select a file from your local filesystem. The automatic fields should display the file details. Enter the required metadata (content type, content ID, and category ID) in the respective input fields. Click the `Save` button to convert the file to binary and store it in the database with the provided metadata.
   
      **6. Retrieving and Displaying Data:**
           After saving the data, you can click the `Refresh` button to update the DataGridView with the contents of the database. The data should be displayed in a tabular format, including the DataID, FileName, FilePath, Extension, FileSize, ContentType, ContentID, and CategoryID.
      
      **7. Viewing Stored Content:**
           To view the content of a stored file, select the corresponding row in the DataGridView, and then click the `Open` button. The application will retrieve the binary data from the database and display it to the user, allowing you to view the content of the selected file.
      
      * You can customize the code according to your specific database and data types to seamlessly integrate the File to Binary Converter and Database Storage functionality with your application. This flexibility allows you to tailor the application to your unique requirements, ensuring a smooth and efficient data storage and retrieval process.

# Contributing
Contributions are welcome. Please submit pull requests for any changes or improvements you would like to make.
I hope this helps!
           
            

        

          
      
      
     
      



   
