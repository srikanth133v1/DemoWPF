# DemoWPF
A sample application using MVP pattern and Moq

0
This project contains implementation of below requirment

Using Visual Studio create a windows application consisting of a single window with a single button. 
The button is initially called 'Start'. 
When pressed execution starts and the button changes to 'Stop'. 
If pressed while executing, execution stops and the bottom changes to back to 'Start' 
When executing, the program will once a second: 
- retrieve a JSON formatted string from this URL:  - Perform the math operation requested. The operation is either +,-,/,* - Show the full equation and result in the window. Example “3 + 5 = 8” - It is desirable to have a log type list of the equations that can be scrolled through 

This project is implemented using 
1) MVP pattern
2) Windows Forms
3) Used DispatcherTimer to similuate requests for every second

Thirdparty Dependencies:
1) Newtonsoft.JSON (used to JSON response deserialization)
2) Moq for unit testing

Additional information:
1) Update appsettings in DemoCalculatorClient.exe.config  
2) Launch DemoCalculatorClient.exe located in /bin/Debug (or release folder)
