using System;
using System.Collections.Generic;

/*********************<< Note >>*************************

    This console app is developed by Zwe Min Oo.
    https://www.github.com/zweminoo
    You can use code freely but please read
    to understand the code before you use.
    Don't use by just changing my app info for any purpose.

    Explanation about ToDoApp app :

    The process of this app is just keeping the records of 
    To Do, Doing and Done of a person's work.
    You can do create, update delete and retieve tasks
    in CLI.

    Purpose :
    
    For understanding how to create a progam that contains
    CRUD functions in programming.
********************************************************/
namespace ToDoApp
{
    class AppInfo { // App Details
        // Declaring and assigning variable
        public readonly static string appName = "ToDoApp";
        public readonly static string appVersion = "V1.0.0";
        public readonly static string releaseDate = "5-Dec-2019";
        public readonly static string developer = "Zwe Min Oo";
        public readonly static string logo = ""+
        "TTTTTTT        DDDDD            AAA\n"+                  
        "  TTT    oooo  DD  DD   oooo   AAAAA  pp pp   pp pp\n"+  
        "  TTT   oo  oo DD   DD oo  oo AA   AA ppp  pp ppp  pp\n"+
        "  TTT   oo  oo DD   DD oo  oo AAAAAAA pppppp  pppppp\n"+ 
        "  TTT    oooo  DDDDDD   oooo  AA   AA pp      pp\n"+     
        "                                      pp      pp";   
    }
    class Task { // Task Info
        // Declaring variable
        int no;
        string date;
        string details;
        Status status;
        //Constructor
        public Task(int no,string date, string details, Status status) {
            this.no = no;
            this.date = date;
            this.details = details;
            this.status = status;
        }
        // Getters
        public int getNo(){
            return this.no;
        }
        public string getDate(){
            return this.date;
        }
        public string getDetails(){
            return this.details;
        }
        public Status getStatus(){
            return this.status;
        }
        // Setters
        public void setNo(int no){
            this.no = no;
        }
        public void setDate(string date){
            this.date = date;
        }
        public void setDetails(string details){
            this.details = details;
        }
        public void setStatus(Status status){
            this.status = status;
        }
        //Functions
        public void print(){
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Task's status : " + this.status.getStatusName());
            Console.WriteLine("*******************************************************");
            Console.WriteLine("No   Date    Details\n");
            Console.WriteLine(this.no + "    "+this.date+"   "+this.details);
            Console.WriteLine("*******************************************************");
        }
    }
    class Status { // Status Info
        // Declaring variable
        string statusName;
        readonly string [] statusList = {"TO DO","DOING","DONE"};
        // Constructor
        public Status(){
            this.statusName = statusList[0]; // Default Status is TO DO
        }
        public Status(int index) {
            statusName = statusList[index];
        }
        // Getters
        public string getStatusName(){
            return this.statusName;
        }
        public string[] getStatusList(){
            return this.statusList;
        }
        // Setters
        public void setStatusName(string name){
            this.statusName = name;
        }
        // no setter for statusList because it should not be modify
    }
    class Data { // Keeping data and doing functions
        // Declaring variable
        List<Task> taskList;
        // Constructor
        public Data(){
            taskList = new List<Task>();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task List created");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Functions
        public void clearList() {
            taskList.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<< Task List cleared >>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void createTask() {
            int no;
            string date, details;
            Status status;

            if(taskList.Count == 0) {
                no = 1;
            }
            else {
                no = taskList[taskList.Count-1].getNo() + 1;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter date");
            Console.ForegroundColor = ConsoleColor.White;
            date = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter details");
            Console.ForegroundColor = ConsoleColor.White;
            details = Console.ReadLine();
            
            status = new Status(); // default - TO DO
            taskList.Add(new Task(no,date,details,status));     
            Console.WriteLine("Status set default - TO DO");
            Console.ForegroundColor = ConsoleColor.Green;            
            Console.WriteLine("<< New task created. >>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void deleteTask(int no){
            Boolean isFound = false;
            foreach(Task task in taskList){
                if( task.getNo() == no){
                    isFound = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Task to delete:");
                    Console.ForegroundColor = ConsoleColor.Cyan;               
                    task.print();
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("<< Are you sure want to delete?\nType Y for yes/ N for cancel. >>");
                    Console.ForegroundColor = ConsoleColor.White;
                    String confirm = Console.ReadLine();

                    if(String.Equals(confirm,"Y")){
                        taskList.Remove(task);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<< Task Deleted >>");
                        Console.ForegroundColor = ConsoleColor.White;                       
                    }
                    else{
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("<< Canceled Deletion >>");
                    }
                    break;
                }
            }
            if(isFound==false){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<< Delete Failed! Task No. Not Found >>");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void updateTaskDate(int no){
            Boolean isFound = false;
            foreach(Task task in taskList){
                if( task.getNo() == no){
                    isFound = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Task to update :");
                    Console.ForegroundColor = ConsoleColor.Cyan;               
                    task.print();
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("<< Enter new dete\nType 0 for cancel. >>");
                    Console.ForegroundColor = ConsoleColor.White;
                    String date = Console.ReadLine();

                    if(String.Equals(date,"0")){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("<< Canceled task's date update. >>");
                    }
                    else{
                        taskList[taskList.IndexOf(task)].setDate(date);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<< Task's date updated. >>");
                    }
                    break;
                }
            }
            if(isFound==false){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<< Update Failed!Task No. Not Found. >>");
            }
            Console.ForegroundColor = ConsoleColor.White;  
        }
        public void updateTaskDetails(int no){
            Boolean isFound = false;
            foreach(Task task in taskList){
                if( task.getNo() == no){
                    isFound = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Task to updates :");
                    Console.ForegroundColor = ConsoleColor.Cyan;               
                    task.print();
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(this.getStatusList());
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("<< Enter new details\nType 0 for cancel. >>");
                    Console.ForegroundColor = ConsoleColor.White;
                    String details = Console.ReadLine();

                    if(String.Equals(details,"0")){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("<< Canceled details update. >>");
                    }
                    else{
                        taskList[taskList.IndexOf(task)].setDetails(details);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<< Task's details updated >>");
                    }
                    break;
                }
            }
            if(isFound==false){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Update failed!Task's No. not found.\n");
            }
            Console.ForegroundColor = ConsoleColor.White;  
        }
        public void updateTaskStatus(int no){
            Boolean isFound = false;
            foreach(Task task in taskList){
                if( task.getNo() == no){  
                    isFound = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Task to updates :");
                    Console.ForegroundColor = ConsoleColor.Cyan;               
                    task.print();
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(this.getStatusList());
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter Status No\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    int statusNo = Convert.ToInt32(Console.ReadLine());

                    while(statusNo<1 && statusNo>3){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("<< Please type a valid status number >>");
                        Console.ForegroundColor = ConsoleColor.White;
                        statusNo = Convert.ToInt32(Console.ReadLine());
                        taskList[taskList.IndexOf(task)].setStatus(new Status(statusNo-1));
                    }
                    task.setStatus(new Status(statusNo-1));
                    break;
                }
            }
            if(isFound==false){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<< Task's No. not found. >>");
            }
            else{
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<< Task's status updated. >>");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public string getStatusList(){
            Status statusObj = new Status();
            string [] statusList = statusObj.getStatusList();
            int length = statusList.Length;
            string status = "Status : ";
            for(int i = 0; i<length ;i++){
               status += i+1 + " - " + statusList[i] + " / ";
            }
            return status;
        }
        public void printData(int statusNo){
            Status status = new Status();
            string [] statusList = status.getStatusList();
            int numOfStatus = statusList.Length;

            if(statusNo == 0){
                for(int i = 0;i < numOfStatus;i++){
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Task's status : " +statusList[i]);
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("No   Date    Details\n");
                    foreach(Task task in taskList) {
                        string statusName = task.getStatus().getStatusName();
                        if(String.Equals(statusName,statusList[i])){
                            Console.WriteLine(task.getNo() + "    "+task.getDate()+"   "+task.getDetails());
                        }
                    }
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine();
                }
                if(statusList.Length==0){
                        Console.WriteLine("<< No task created. >>");
                    }
            }
            else {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("*******************************************************");
                Console.WriteLine("Task's status : " +statusList[statusNo - 1]);
                Console.WriteLine("*******************************************************");
                Console.WriteLine("No   Date    Details\n");
                foreach(Task task in taskList) {
                    string statusName = task.getStatus().getStatusName();
                    if(String.Equals(statusName,statusList[statusNo - 1])){
                        Console.WriteLine(task.getNo() + "    "+task.getDate()+"   "+task.getDetails());
                    }
                }
                Console.WriteLine("*******************************************************");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }    
    }
    class App { // Creating UI in console and getting user's actions
        // Declaring variable
        Data data;
        // Constructor  
        public App(){
            data = new Data();
        }
        // Functions
        public void wait(){
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void run(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            string cmdInfo = "Commands \n task -new\n task -remove\n task -update -date\n task -update -details\n task -update -status\n clearlist\n showlist\n exit";
            string status = data.getStatusList();
            string cmd = "";
            Boolean isRun = true;
            while(isRun){
                /************* App Intro ***************/
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*******************************************************");
                Console.WriteLine(AppInfo.logo);
                Console.WriteLine("*******************************************************");
               
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*******************************************************");
                Console.WriteLine("App Name : " + AppInfo.appName + "          Version : " + AppInfo.appVersion);
                Console.WriteLine("Release Date : " + AppInfo.releaseDate + "   Developer : " + AppInfo.developer);
                Console.WriteLine("*******************************************************");

                Console.Title = AppInfo.appName;
                //Showing Commands
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("*******************************************************");
                Console.WriteLine(cmdInfo);
                Console.WriteLine("*******************************************************");

                /************* Asking user for command ***************/
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Type a command :");
                Console.ForegroundColor = ConsoleColor.White;
                cmd = Console.ReadLine();

                if(String.Equals(cmd, "task -new")){
                    data.createTask();
                    this.wait();
                }
                else if(String.Equals(cmd, "task -remove")){
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter task's no. :");
                    Console.ForegroundColor = ConsoleColor.White;

                    data.deleteTask(Convert.ToInt32(Console.ReadLine()));
                    this.wait();
                }
                else if(String.Equals(cmd, "task -update -date")){
                    data.printData(0);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter task's no. :");
                    Console.ForegroundColor = ConsoleColor.White;

                    data.updateTaskDate(Convert.ToInt32(Console.ReadLine()));
                    this.wait();
                }
                else if(String.Equals(cmd, "task -update -details")){
                    data.printData(0);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter task's no. :");
                    Console.ForegroundColor = ConsoleColor.White;

                    data.updateTaskDetails(Convert.ToInt32(Console.ReadLine()));
                    this.wait();
                }
                else if(String.Equals(cmd, "task -update -status")){
                    data.printData(0);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter task's no. :");
                    Console.ForegroundColor = ConsoleColor.White;

                    data.updateTaskStatus(Convert.ToInt32(Console.ReadLine()));
                    this.wait();
                }
                else if(String.Equals(cmd, "clearlist")){
                    data.clearList();
                    this.wait();
                }
                else if(String.Equals(cmd,"showlist")){
                    Console.WriteLine(status);
                    Console.WriteLine("0 - show all");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter status no. :");
                    Console.ForegroundColor = ConsoleColor.White;

                    data.printData(Convert.ToInt32(Console.ReadLine()));
                    this.wait();
                }
                else if(String.Equals(cmd, "exit")){
                    Console.Clear();
                    isRun = false;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("<< Please type a valid command! >>");
                    Console.ForegroundColor = ConsoleColor.White;
                    this.wait();                 
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    class Program // Execute the Program
    {
        static void Main(string[] args)
        {
            new App().run();
        }
    }
}