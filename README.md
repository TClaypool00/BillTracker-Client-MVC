# Bill Tracker Client (C# MVC Edition)

## Prerequisites
### Download XAMPP
1. If you do not have it installed already, please install XAMPP. You can do so by going to by clicking this link https://www.apachefriends.org/
2. Follow the onscreen directions to install the program.
3. Once it is installed, run the XAMPP appliaction. (It is recommend that you are an adminstrator)

### Create a Bill Tracker database
1. Click the "Start" button beside "Appache" and "MySQL".
2. Click the "Admin" button beside "MySQL", it will take you to the phpMyAdmin website.
3. Click the SQL tab at the top.
4. Copy the follwing code.
```sql
CREATE DATABASE billtracker
```
5. Paste in the text area of the SQL tab.


### Download the source code
1. Either download or clone the git repository to your desired location.

### Additional Files
1. Copy the following code

```c#
namespace BillTrackerClient.App.DataModels
{
    public class SecretConfig
    {
        public static string ConnectionString { get; } = "server={your server};user={your username};password={your password};database=billtracker";
    }
}

```

2. Create a file a name it "SecretConfig.cs". (case sensitive) and place it in the "DataModels" Folder

## Usage
1. Press "Ctrl + F5" to start without debugging.
2. Press "F5" to start in debugging.
3. <b>Note:</b> XAMPP and both the  "MySQL" and "Appache" module must be running the while you are using the application.