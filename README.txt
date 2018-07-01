1. Install 
	- RabbitMq & Erlang 
		1) http://erlang.org/download/otp_win64_20.3.exe
		2) https://dl.bintray.com/rabbitmq/all/rabbitmq-server/3.7.5/rabbitmq-server-3.7.5.exe

2. Install .Net Framework 4.6

------------------------------------------------------------------------------------------

[Note: No need to change any connection string for RabbitMq, By default it is "host=localhost"]

Techologies Used: 
	1. RabbitMq (Messsaging Bus)
	2. Asp.Net 4.6 (Console App) 
	3. Asp.Net MVC, 
	4. Unity (IOC Container) -- For injecting the RabbitMq Connection object into the controller
	5. and EasyNetQ (.Net Rabbitmq Client) -- Easy of using the RabbitMq, it has good API's to access the messages

Software Architecture Details are provided in the Dcoument (FirstScreen.docx)

[Optional Requirement Implemented]
	- Web Application to Consume the data
	- Random Data Generation like same as XML file 
		- app.config : you can set Max random data count and Input filename as well 

=> Input File : Should in the working Directory, I have Created Already one, you can refer that.

Running the Application

	1. Application A: 
		Project Name : FirstScreen.Publisher.Host 
		Command Eg: C:\bin\A>FirstScreen.Publisher.Host.exe slow
		Command Params : slow, fast

	2. Application B: 
		Project Name : FirstScreen.Subscriber.Host 
		Command Eg: C:\bin\B>FirstScreen.Subscriber.Host.exe green
		Command Params : green,red,blue

	3. Application C:
		Project Name : FirstScreen.Subscriber.Web
		Run : Directly from Visual Studio or Host on IIS 
		QueryString : http://<baseUrl>/?type=red
		Possible types: ?type=[green, red, or blue]